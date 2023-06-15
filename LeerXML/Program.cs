using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LeerXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ruta del archivo XML
            string xmlFilePath = "C:\\Users\\aguil\\OneDrive\\Documentos\\Sibaja\\Tesis\\LeerXML\\Configuraciones.xml";

            // Crear un objeto XmlDocument
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                // Cargar el archivo XML
                xmlDoc.Load(xmlFilePath);

                // Obtener todos los elementos "configsection"
                XmlNodeList configSections = xmlDoc.SelectNodes("//configsection");

                // Recorrer cada elemento "configsection"
                foreach (XmlNode configSection in configSections)
                {
                    // Obtener el valor del atributo "name"
                    string name = configSection.Attributes["name"].Value;

                    // Obtener los elementos hijos de "configsection"
                    XmlNodeList childNodes = configSection.ChildNodes;

                    // Mostrar las propiedades del elemento
                    Console.WriteLine($"Propiedades de {name}:");

                    foreach (XmlNode childNode in childNodes)
                    {
                        string propertyName = childNode.Name;
                        string propertyValue = childNode.InnerText;

                        Console.WriteLine($"{propertyName}: {propertyValue}");
                    }

                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al leer el archivo XML: " + e.Message);
            }

            Console.WriteLine();
        }
    }
}
