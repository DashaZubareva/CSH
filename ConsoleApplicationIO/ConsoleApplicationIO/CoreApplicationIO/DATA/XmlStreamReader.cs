using CoreApplicationIO;
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
    /// <summary>
	/// Base class for XML writers.
	/// </summary>
	public class XmlStreamReader : IDisposable
    {
        //private string xmlNamespace;
        private XmlReader xmlReader;
        //protected string readerElementName;

        /// <summary>
        /// Begins the writing.
        /// </summary>
        public XmlStreamReader(Stream xmlStream)
        {
            xmlReader = XmlReader.Create(xmlStream);
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

        public Car Deserialize()
        {
            var xmlSerializer = new XmlSerializer(typeof(Car));
            return (Car)xmlSerializer.Deserialize(xmlReader);
        }
    }

}
