using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegaate
{
   public class ConvertorTemperature
    {
             static public void CelcToFar (double cel)
            // static public double CelcToFar (double cel)
        {
            Console.WriteLine("\nConvert from Celcii "+ cel + "C  To Farengeit=" + (cel * 9 / 5 + 32)+" Far");
           // return cel * 9/5+32;
        }
     
        static public void FarToCel(double far)
             // static public double FarToCel(double far)
        {
            Console.WriteLine("\nConvert from Farengeit " + far + "Far To Celcii=" + ((far - 32) / 1.800) + " C");
           // return (far-32) /1.800;
        }
    }
}
