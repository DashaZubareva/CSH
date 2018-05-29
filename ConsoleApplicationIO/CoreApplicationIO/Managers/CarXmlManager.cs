using CoreApplicationIO.DATA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApplicationIO
{
    public class CarXmlManager
    {

        string filePath { get; set; }
        StreamReader streamReader { get; set; }
        StreamWriter streamWriter { get; set; }
        public List<Car> Cars { get; private set; }
        private XmlStreamReader xmlReader;

        List<string> SearchFilter { get; set; }

        public CarXmlManager(string filePath)
        {
            this.filePath = filePath;
            Cars = new List<Car>();
            SearchFilter = new List<string>();
        }
        public List<Car> GetCars()
        {
            string line = string.Empty;
            Car car = null;

            Cars.Clear();
            using (Stream stream = new System.IO.FileStream(filePath, FileMode.Open))
            {
                using (xmlReader = new XmlStreamReader(stream))
                {
                    while (xmlReader.Read())
                    {
                        car = xmlReader.Desereliase();
                        if (car != null)
                        {
                            Cars.Add(car);
                        }
                    }
                }
            }
            return Cars;
        }
    }
}

   