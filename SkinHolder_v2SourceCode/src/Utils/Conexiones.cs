using System;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
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

    public static string GetCodigoFuente(string url)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                // Realiza una solicitud HTTP GET a la URL proporcionada
                HttpResponseMessage response = client.GetAsync(url).Result; // Espera sincrónicamente

                // Verifica si la solicitud fue exitosa (código de estado 200)
                if (response.IsSuccessStatusCode)
                {
                    // Lee el contenido de la respuesta como una cadena
                    string codigoFuente = response.Content.ReadAsStringAsync().Result; // Espera sincrónicamente
                    return codigoFuente;
                }
                else
                {
                    Console.WriteLine($"La solicitud a {url} no fue exitosa. Código de estado: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener el código fuente: {ex.Message}");
        }

        return null; // Si ocurre algún error, devuelve null
    }
}