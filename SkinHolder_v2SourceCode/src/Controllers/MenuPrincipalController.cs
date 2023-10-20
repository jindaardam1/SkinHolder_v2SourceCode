using SkinHolder_v2SourceCode.Utils;

namespace SkinHolder_v2SourceCode.Controllers;

public class MenuPrincipalController
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
}