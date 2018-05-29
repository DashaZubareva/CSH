using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    class Program
    {
        private static readonly List<string> Columns = new List<string>
        {
            "CarId",
            "Model",
            "Version",
            "Engine",
            "Displancement",
            "Speed",
            "Date"
        };
        static void Main(string[] args)
        {
            var dataGenerator = new DataGenerator();
            using (Stream fileStream = new System.IO.FileStream("c:\\DATA\\XXX.csv", FileMode.Create))
            {
                using (var csvStreamWriter = new CsvStreamWriter(fileStream, true))
                {
                    // add header
                    csvStreamWriter.WriteLine(Columns);
                    foreach (var item in dataGenerator.GetData())
                    {
                        csvStreamWriter.WriteLine(item.StoreFormat().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries));
                    }
                }
            }

            Console.WriteLine("Data generation is completed!");
            Console.ReadKey();

            using (Stream fileStream = new System.IO.FileStream("D:\\Daria\\DATA\\XXX.xml", FileMode.Create))
            {
                var xmlStreamWriter = new XmlStreamWriter();
                xmlStreamWriter.Begin(fileStream, "Cars", "http://www.develop.com/car", new Dictionary<string, string>());

                foreach (var item in dataGenerator.GetData())
                {
                    xmlStreamWriter.WriteElement(item);
                }
                xmlStreamWriter.Finish();
            }

            Console.WriteLine("Data generation is completed!");
            Console.ReadKey();

        }
    }
}
