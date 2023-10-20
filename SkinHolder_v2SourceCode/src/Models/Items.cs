using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using SkinHolder_v2SourceCode.Records;
using SkinHolder_v2SourceCode.Utils;

namespace SkinHolder_v2SourceCode.Models;

/// <summary>
    /// Clase para almacenar los items.
    /// </summary>
    public class Items
    {
        /// <summary>
        /// Diccionario que almacena los items con su respectivo nombre como clave.
        /// </summary>
        public SortedDictionary<string, Item> SortDicItems;

        /// <summary>
        /// Constructor de la clase Items que inicializa el diccionario y agrega los items existentes.
        /// </summary>
        public Items()
        {
            SortDicItems = new SortedDictionary<string, Item>();
            AgregarItems();
        }

        /// <summary>
        /// Método para obtener el diccionario de items.
        /// </summary>
        /// <returns>El diccionario de items.</returns>
        public SortedDictionary<string, Item> GetItems()
        {
            return SortDicItems;
        }

        /// <summary>
        /// Método privado que lee los archivos XML de la carpeta Items y agrega los items al diccionario.
        /// </summary>
        private void AgregarItems()
        {
            try
            {
                var archivosXml = Directory.GetFiles("Items");

                foreach (var archivo in archivosXml)
                {
                    var doc = new XmlDocument();
                    doc.Load(archivo);

                    if (doc.DocumentElement != null)
                    {
                        var root = doc.DocumentElement;

                        // Obtener el nombre, cantidad y enlace de cada item del archivo XML.
                        var nombre = root.SelectSingleNode("/item/nombre").InnerText;
                        var cantidad = int.Parse(root.SelectSingleNode("/item/cantidad").InnerText);
                        var enlace = root.SelectSingleNode("/item/id").InnerText;

                        // Crear el item y agregarlo al diccionario de items.
                        var item = new Item(enlace, cantidad);
                        SortDicItems[nombre] = item;
                    }
                }
            }
            catch (XPathException e)
            {
                Logs.ErrorLogManager(e);
            }
        }
    }