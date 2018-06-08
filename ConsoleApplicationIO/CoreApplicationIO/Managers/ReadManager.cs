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
        string filePath { get; set; }
        StreamReader streamReader { get; set; }
        StreamWriter streamWriter { get; set; }
        public List<Car> Cars { get; private set; }

        byte[] range;

        public ReadManager(string filePath)
        {
            this.filePath = filePath;            
        }
        

        public void readRange()
        {
            byte[] part =new byte[100000];

            using (FileStream fs = File.OpenRead(filePath))
            {
                byte[] b = new byte[500];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                }
            }
        }
        
        }

    }
