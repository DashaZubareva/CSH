using CoreApplicationIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CoreApplicationIO.DATA
{
    /// <summary>
	/// Base class for XML writers.
	/// </summary>
	public class XmlStreamReader : IDisposable
    {
        //private string xmlNamespace;
        private XmlReader xmlReader;
        //protected string readerElementName;
        public const string xsdFileName = "Data.xsd";

        /// <summary>
        /// Begins the writing.
        /// </summary>
        public XmlStreamReader(Stream xmlStream)
        {
            var resourceName = string.Format("{0}.{1}", GetType().Namespace, xsdFileName);
            var xsdStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);

            var xmlReaderSettings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
            };

            xmlReaderSettings.Schemas.Add(null, XmlReader.Create(xsdStream));
            xmlReaderSettings.ValidationEventHandler += ValidationEventHandler;

            xmlReader = XmlReader.Create(xmlStream, xmlReaderSettings);
        }

        public bool Read()
        {

            while (xmlReader.Read())
            {
                if (xmlReader.Name == Car.XmlElementName)
                {
                    return true;
                }
            }

            return false;
        }

        public string ReadContentAsString()
        {
            return xmlReader.ReadOuterXml();
        }

        /// <summary>
        /// Finishs the writing.
        /// </summary>
        public void Finish()
        {
            xmlReader.Close();
        }

        /// <summary>
        /// Releases all resources used by the current instance class.
        /// </summary>
        public void Dispose()
        {
            xmlReader.Dispose();
        }

        public Car Deserialize(string carXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(Car));

            using (TextReader reader = new StringReader(carXml))
            {
                return (Car)xmlSerializer.Deserialize(reader);
            }
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }

        }
    }

}
