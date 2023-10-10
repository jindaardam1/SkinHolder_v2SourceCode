using System;
using System.IO;

namespace SkinHolder_v2SourceCode.Utils
{
    /// <summary>
    /// Clase para administrar registros de eventos y errores.
    /// </summary>
    public class Logs
    {
        /// <summary>
        /// Registra un error en el registro de errores.
        /// </summary>
        /// <param name="e">La excepción que se registrará en el log.</param>
        public static void ErrorLogManager(Exception e)
        {
            AddLog(CreateLogString("ERROR", e.ToString()));
        }

        
        /// <summary>
        /// Registra un error personalizado en el registro de errores.
        /// </summary>
        /// <param name="errorPersonalizado">El mensaje de error personalizado a registrar en el log.</param>
        public static void ErrorLogManager(string errorPersonalizado)
        {
            AddLog(CreateLogString("ERROR", errorPersonalizado));
        }

        
        /// <summary>
        /// Registra un mensaje de depuración en el registro de eventos.
        /// </summary>
        /// <param name="mensaje">El mensaje de depuración a registrar en el log.</param>
        public static void DebugLogManager(string mensaje)
        {
            AddLog(CreateLogString("DEBUG", mensaje));
        }

        
        /// <summary>
        /// Registra un mensaje de información en el registro de eventos.
        /// </summary>
        /// <param name="mensaje">El mensaje de información a registrar en el log.</param>
        public static void InfoLogManager(string mensaje)
        {
            AddLog(CreateLogString("INFO", mensaje));
        }

        
        /// <summary>
        /// Crea una cadena de registro formateada.
        /// </summary>
        /// <param name="tipoLog">El tipo de registro (por ejemplo, "INFO", "ERROR", "DEBUG").</param>
        /// <param name="mensajeLog">El mensaje de registro.</param>
        /// <returns>La cadena de registro formateada.</returns>
        private static string CreateLogString(string tipoLog, string mensajeLog)
        {
            const string logFormat = "{0} [{1}] -> {2}";
            return string.Format(logFormat, GetFechaHoraActual(), tipoLog, mensajeLog);
        }

        
        /// <summary>
        /// Agrega un registro de log al archivo de registro del mes actual.
        /// </summary>
        /// <param name="nuevoLog">El registro de log a agregar.</param>
        private static void AddLog(string nuevoLog)
        {
            var nombreArchivo = GetNombreArchivoLogMesActual();
            var rutaCompletaArchivo = Path.Combine(GetCarpetaLogs(), nombreArchivo);

            try
            {
                using (var sw = File.AppendText(rutaCompletaArchivo))
                {
                    sw.WriteLine(nuevoLog);
                }
            }
            catch (IOException e)
            {
                // ignored
            }
        }

        
        /// <summary>
        /// Obtiene el nombre del archivo de registro del mes actual.
        /// </summary>
        /// <returns>El nombre del archivo de registro del mes actual.</returns>
        private static string GetNombreArchivoLogMesActual()
        {
            var fechaActual = DateTime.Now.ToString("yyyy-MM");
            return fechaActual + ".log";
        }

        
        /// <summary>
        /// Obtiene la carpeta de registros (logs).
        /// </summary>
        /// <returns>Ruta completa de la carpeta de registros.</returns>
        private static string GetCarpetaLogs()
        {
            var carpetaLogs = "logs";

            if (!Directory.Exists(carpetaLogs))
            {
                Directory.CreateDirectory(carpetaLogs);
            }

            return carpetaLogs;
        }
        

        /// <summary>
        /// Devuelve la fecha y hora actual formateada como una cadena.
        /// </summary>
        /// <returns>La fecha y hora actual en el formato "yyyy-MM-dd HH:mm:ss".</returns>
        private static string GetFechaHoraActual()
        {
            // Obtiene la fecha y hora actual.
            var now = DateTime.Now;
            // Devuelve la fecha y hora formateada como una cadena.
            return now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}