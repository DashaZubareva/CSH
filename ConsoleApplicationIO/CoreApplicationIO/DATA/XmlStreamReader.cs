using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CoreApplicationIO.DATA
{
    class XmlStreamReader : IDisposable
    {
        private string xmlNamespace;
        protected XmlReader xmlReader;
        private string readerElementName;
        


        public XmlStreamReader(Stream xmlStream, string readElementName)
        {
            xmlReader =  XmlReader.Create(xmlStream);
            this.readerElementName = readElementName;
        }


        public XmlStreamReader(Stream xmlStream)
        {
            xmlReader = XmlReader.Create(xmlStream);  
        }

        /// <summary>
        /// Writes the passed data element.
        /// </summary>
        /// <param name="carElement">The data element to be written.</param>
        /*public void WriteElement(Car carElement)
        {
            Serialize(carElement);
        }*/
        public bool Read()
        {
           while (xmlReader.Read())
            {
                if (xmlReader.Name==Car.XmlElementNAme)
                {
                    return true;
                }
            }
            return false;
        }

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

        public Car Desereliase ()
        {
            var xmlSerializer = new XmlSerializer(typeof(Car));
            return (Car)xmlSerializer.Deserialize(xmlReader);
        }
    }

}

