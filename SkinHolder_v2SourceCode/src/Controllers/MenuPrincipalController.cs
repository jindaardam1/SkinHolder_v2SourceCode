using System;
using System.Globalization;
using SkinHolder_v2SourceCode.Utils;

namespace SkinHolder_v2SourceCode.Controllers;

public static class MenuPrincipalController
{
    public static string GetPing(string host)
    {
        var ping = Conexiones.HayConexion(host);

        if (ping == -1)
        {
            return "sin conexión";
        }
        {
            return ping.ToString();
        }
    }

    public static string GetYuanesAEuros()
    {
        return ConversionDivisas.CodigoACambio(
            Conexiones.GetCodigoFuente(ConversionDivisas.ConstruirEnlace("CNY", "EUR"))).ToString(CultureInfo.CurrentCulture);
    }

    public static string GetEurosAYuanes()
    {
        return ConversionDivisas.CodigoACambio(
            Conexiones.GetCodigoFuente(ConversionDivisas.ConstruirEnlace("EUR", "CNY"))).ToString(CultureInfo.CurrentCulture);

    }
}