using System;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.NetworkInformation;
using HtmlAgilityPack;

namespace SkinHolder_v2SourceCode.Utils;

public class Conexiones
{
    public static int HayConexion(string host)
    {
        var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        try
        {
            var addresses = Dns.GetHostAddresses(host);
            if (addresses.Length > 0)
            {
                var ping = new Ping();
                var reply = ping.Send(addresses[0], 5000);
                if (reply.Status == IPStatus.Success)
                {
                    var endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    return (int)(endTime - startTime);
                }
            }
        }
        catch (IOException e)
        {
            Logs.ErrorLogManager(e);
        }
        return -1;
    }

    public static string? GetCodigoFuente(string url)
    {
        try
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");

                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var html = response.Content.ReadAsStringAsync().Result;

                    var htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(html);

                    return htmlDocument.DocumentNode.OuterHtml;
                }
                else
                {
                    Logs.ErrorLogManager("No se pudo obtener una respuesta válida del servidor. Código de estado: " + (int)response.StatusCode);
                    return null;
                }
            }
        }
        catch (Exception e)
        {
            Logs.ErrorLogManager(e);
            return null;
        }
    }
}