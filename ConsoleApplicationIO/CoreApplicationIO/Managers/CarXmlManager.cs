using CoreApplicationIO.Common;
using CoreApplicationIO.DATA;
using CoreApplicationIO.Interfaces;
using CoreApplicationIO.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace CoreApplicationIO.Managers
{
    public class CarXmlManager //: ICarManager
    {
        string filePath { get; set; }
        StreamReader streamReader { get; set; }
        StreamWriter streamWriter { get; set; }
        public List<Car> Cars { get; private set; }

        private XmlStreamReader xmlStreamReader { get; set; }

        List<string> SearchFilter { get; set; }

        public CarXmlManager(string filePath)
        {
            this.filePath = filePath;
            Cars = new List<Car>();
            SearchFilter = new List<string>();
        }
        public List<Car> GetCars()
        {
            Car car = null;

            Cars.Clear();
            using (Stream stream = new System.IO.FileStream(filePath, FileMode.Open))
            {
                using (xmlStreamReader = new XmlStreamReader(stream))
                {
                    while (xmlStreamReader.Read())
                    {
                        string tmp = xmlStreamReader.ReadContentAsString();
                        car = xmlStreamReader.Deserialize(tmp);
                        if (car != null)
                        {
                            Cars.Add(car);
                        }
                    }
                }
            }
            return Cars;
        }

        public List<Car> GetCars(SearchFilter filter)
        {
            Car car = null;

            Cars.Clear();
            using (Stream stream = new System.IO.FileStream(filePath, FileMode.Open))
            using (xmlStreamReader = new XmlStreamReader(stream))
            {
                while (xmlStreamReader.Read())
                {
                    string tmp = xmlStreamReader.ReadContentAsString();
                    if (tmp.Contains(filter.Model)
                       &&
                       tmp.Contains(filter.Year)
                       &&
                       tmp.Contains(filter.Engine)
                       &&
                       IsCarInDateRange(tmp, filter.DateFrom, filter.DateTo)
                       )
                    {
                        car = xmlStreamReader.Deserialize(tmp);
                        if (car != null)
                        {
                            Cars.Add(car);
                        }
                    }
                    
                }
            }
            
            return Cars;
        }

        public Car GetCar(Guid carId)
        {
            Car car = null;

            Cars.Clear();
            using (Stream stream = new System.IO.FileStream(filePath, FileMode.Open))
            using (xmlStreamReader = new XmlStreamReader(stream))
            {
                while (xmlStreamReader.Read())
                {
                    string tmp = xmlStreamReader.ReadContentAsString();
                    if (tmp.Contains(carId.ToString()))
                    {
                        car = xmlStreamReader.Deserialize(tmp);
                        if (car != null)
                        {
                            Cars.Add(car);
                        }
                    }

                }
            }

            return car;
        }

        public bool AddCar(Car car)
        {
            car.CarId = Guid.NewGuid();
            byte[] endtag = System.Text.Encoding.UTF8.GetBytes("</Cars>");

            using (Stream fs = new System.IO.FileStream(filePath, FileMode.Open))
            {
                fs.Seek(-endtag.Length-1, System.IO.SeekOrigin.End);

                var settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true, IndentChars = "\t" };
                XmlWriter tw = XmlWriter.Create(fs, settings);

                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(typeof(Car), string.Empty);

                serializer.Serialize(stringwriter, car, car.xmlns);
                var tmp = stringwriter.ToString();
                Regex rgx = new Regex(@"<\?xml.*>\r\n");

                var cleanCar = rgx.Replace(tmp, "\t");

                tw.WriteRaw("\r\n" + cleanCar + "\r"+ System.Text.Encoding.UTF8.GetString(endtag));// START CHILD
                tw.Flush();//END CHILD
            }
            return true;
        }

        public bool UpdateCar(Car car)
        {
            using (streamWriter = new StreamWriter(filePath))
            {
                foreach (var carItem in Cars)
                {
                    if (carItem.CarId != car.CarId)
                    {
                        streamWriter.WriteLine(carItem.StoreFormat());
                    }
                    else
                    {
                        streamWriter.WriteLine(car.StoreFormat());
                    }
                }
            }
            return true;
        }

        public bool RemoveCar(Car car)
        {
            using (streamWriter = new StreamWriter(filePath))
            {
                foreach (var carItem in Cars)
                {
                    if (carItem.CarId != car.CarId)
                    {
                        streamWriter.WriteLine(carItem.StoreFormat());
                    }
                }
            }
            return true;
        }

        private Car ReadFromRow(string row)
        {
            var values = row.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            if (values.Count() < Constants.CarPropertiesCount) return null;
            try
            {
                var car = new Car
                {
                    CarId = Guid.Parse(values[0]),
                    Model = (CarModel)Enum.Parse(typeof(CarModel), values[1]),
                    ModelVersion = values[2],
                    Engine = values[3],
                    Displacement = int.Parse(values[4]),
                    Speed = double.Parse(values[5]),
                    Date = DateTime.Parse(values[6])
                };
                return car;
            }
            catch
            {
                return null;
            }
        }

        private bool IsCarInDateRange(string carLine, DateTime? dateFrom, DateTime? dateTo)
        {
            var carDateString = string.Empty;
            var carDate = DateTime.Now;
            var regEx = new Regex(Constants.RegExDatePattern);
            carDateString = regEx.Match(carLine).Value;

            return ((DateTime.TryParse(carDateString, out carDate))
                    &&
                     (dateFrom.HasValue && carDate >= dateFrom || !dateFrom.HasValue)
                    &&
                    (dateTo.HasValue && carDate <= dateTo || !dateTo.HasValue));
        }
    }
}