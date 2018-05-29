using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CoreApplicationIO
{
    [Serializable]
	public class Car
	{
        [XmlAttribute]
        public Guid CarId { get; set; }

        [XmlAttribute]
        public CarModel Model { get; set; }

        [XmlAttribute]
        public string ModelVersion { get; set; }

        [XmlAttribute]
        public string Engine { get; set; }

        // Volume in cm cube
        [XmlAttribute]
        public int Displacement { get; set; }

        [XmlAttribute]
        public double Speed { get; set; }

        [XmlAttribute]
        public DateTime Date { get; set; }

        public string DisplayString()
		{
			return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}(cm.cube){0}{6}(km/h){0}{7}{0}", " "
				,CarId, Model.ToString(), ModelVersion, Engine, Displacement, Speed, Date.ToString("dd.MM.yyyy"));
		}

		public string StoreFormat()
		{
			return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}", ";"
				,CarId, Model.ToString(), ModelVersion, Engine, Displacement, Speed, Date.ToString("dd.MM.yyyy"));
		}
	}
}
