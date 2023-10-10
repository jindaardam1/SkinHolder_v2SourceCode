using System;
using System.IO;

namespace SkinHolder_v2SourceCode.Utils
{
    public static class CrearRecursosNecesarios
    {
        public static void CreacionRecursos()
        {
            CrearCarpetaLogs();
            CrearCarpetaNecesaria("Registros");
            CrearCarpetaNecesaria("Items");
        }

        private static void CrearCarpetaLogs()
        {
            try
            {
                if (!Directory.Exists("Logs"))
                {
                    Directory.CreateDirectory("Logs");
                }
            }
            catch (Exception e)
            {
                // ignored
            }
        }
        
        private static void CrearCarpetaNecesaria(string carpeta)
        {
            try
            {
                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                    Logs.InfoLogManager($"Se ha creado la carpeta {carpeta}");
                }
            }
            catch (Exception e)
            {
                Logs.ErrorLogManager(e);
            }
        }
    }
}