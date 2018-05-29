using CoreApplicationIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DataGenerator
{
    /// <summary>
	/// Base class for XML writers.
	/// </summary>
	public class XmlStreamWriter : IDisposable
    {
        private string xmlNamespace;
        protected XmlWriter xmlWriter;

        /// <summary>
        /// Begins the writing.
        /// </summary>
        public void Begin(Stream xmlStream, string rootElementName, string xmlNamespace, Dictionary<string, string> attributes)
        {
            this.xmlNamespace = xmlNamespace;

            var writerSettings = new XmlWriterSettings { Indent = true, IndentChars = "\t" };
            xmlWriter = XmlWriter.Create(xmlStream, writerSettings);
            xmlWriter.WriteStartElement(rootElementName, xmlNamespace);

            foreach (var attribute in attributes)
            {
                xmlWriter.WriteAttributeString(attribute.Key, attribute.Value);
            }
        }

        /// <summary>
        /// Writes the passed data element.
        /// </summary>
        /// <param name="carElement">The data element to be written.</param>
        public void WriteElement(Car carElement)
        {
            Serialize(carElement);
        }

        /// <summary>
        /// Finishs the writing.
        /// </summary>
        public void Finish()
        {
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }

        /// <summary>
        /// Releases all resources used by the current instance class.
        /// </summary>
        public void Dispose()
        {
            xmlWriter.Dispose();
        }

        protected void Serialize(Car carElement)
        {
            var xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);

            var xmlSerializer = new XmlSerializer(carElement.GetType());
            xmlSerializer.Serialize(xmlWriter, carElement, xmlSerializerNamespaces);
        }
    }

}
