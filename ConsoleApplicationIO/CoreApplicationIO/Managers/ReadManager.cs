using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApplicationIO.Managers
{
    public class ReadManager
    {
        string fileSoursePath { get; set; }
        string fileDestinationPath { get; set; }
        StreamReader streamReader { get; set; }
        StreamWriter streamWriter { get; set; }
        public List<Car> Cars { get; private set; }

        byte[] range;

        public ReadManager(string fileSoursePath, string fileDestinationPath)
        {
            this.fileSoursePath = fileSoursePath;
            this.fileDestinationPath = fileDestinationPath;
        }
        

        public void ReadRange()
        {
            using (FileStream fs = File.OpenRead(fileSoursePath))
            {
                byte[] part = new byte[500];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(part, 0, part.Length) > 0)
                {
                   //if (part.Length < 500)
                  //  {
                        Console.WriteLine(part.Length);
                  //  }
                    WriteRange(part);

                    Console.WriteLine(temp.GetString(part));
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                }
            }
        }
         public void WriteRange(byte[] part)
        {
            using (FileStream fs = new FileStream(fileDestinationPath, FileMode.Append))
            {
                UTF8Encoding temp = new UTF8Encoding(true);

                fs.Write(part, 0, part.Length);
                Console.WriteLine(part.Length);
                Console.WriteLine(temp.GetString(part));
                Console.WriteLine("-------------------------------------------------------------------------------------");
            }
        }
        
        }

    }
