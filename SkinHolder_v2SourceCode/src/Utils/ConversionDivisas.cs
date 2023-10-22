using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using SkinHolder_v2SourceCode.Records;

namespace SkinHolder_v2SourceCode.Utils;

public partial class ConversionDivisas
{
    private const string BaseUrl = "https://www.xe.com/es/currencyconverter/convert/?Amount=1&From={0}&To={1}";

    public static double CodigoACambio(string? codigo)
    {
        try
        {
            var document = new HtmlDocument();
            document.LoadHtml(codigo);
            var pElement = document.DocumentNode.SelectSingleNode("//p[@class='result__BigRate-sc-1bsijpp-1 iGrAod']");

            if (pElement != null)
            {
                var text = pElement.InnerText;
                var doubleValue = MyRegex().Replace(text, "").Replace(',', '.');

                if (double.TryParse(doubleValue, out var result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("No se pudo convertir a double.");
                }
            }
            else
            {
                Console.WriteLine("No se encontró el elemento <p> con la clase proporcionada.");
            }

            return -1;
        }
        catch (Exception e)
        {
            Logs.ErrorLogManager(e);
            return -1;
        }
    }

    public static List<string> ConseguirEnlaces()
    {
        var enlaces = new List<string>
        {
            ConstruirEnlace("EUR", "CNY"),
            ConstruirEnlace("CNY", "EUR"),
            ConstruirEnlace("USD", "CNY"),
            ConstruirEnlace("CNY", "USD"),
            ConstruirEnlace("EUR", "USD"),
            ConstruirEnlace("USD", "EUR"),
            ConstruirEnlace("EUR", "BRL"),
            ConstruirEnlace("BRL", "EUR"),
            ConstruirEnlace("EUR", "RUB"),
            ConstruirEnlace("RUB", "EUR")
        };

        return enlaces;
    }

    private static List<double> CalcularTasas(IEnumerable<string> enlaces)
    {
        return enlaces.Select(enlace => ObtenerCambio(enlace)).ToList();
    }

    private static double ObtenerCambio(string enlace)
    {
        return CodigoACambio(Conexiones.GetCodigoFuente(enlace));
    }

    public static string ConstruirEnlace(string monedaOrigen, string monedaDestino)
    {
        return string.Format(BaseUrl, monedaOrigen, monedaDestino);
    }

    private static List<ParDivisas> ObtenerDivisas()
    {
        var divisas = new List<ParDivisas>();

        divisas.Add(new ParDivisas("EURO", "YUANES"));
        divisas.Add(new ParDivisas("YUAN", "EUROS"));
        divisas.Add(new ParDivisas("DÓLAR", "YUANES"));
        divisas.Add(new ParDivisas("YUAN", "DÓLARES"));
        divisas.Add(new ParDivisas("EURO", "DÓLARES"));
        divisas.Add(new ParDivisas("DÓLAR", "EUROS"));
        divisas.Add(new ParDivisas("EURO", "LIRAS BRASILEÑAS"));
        divisas.Add(new ParDivisas("LIRA BRASILEÑA", "EUROS"));
        divisas.Add(new ParDivisas("EURO", "RUBLOS"));
        divisas.Add(new ParDivisas("RUBLO", "EUROS"));

        return divisas;
    }

    [GeneratedRegex("[^\\d.,]")]
    private static partial Regex MyRegex();
}
