using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegaate
{
    public delegate double Operation(double x, double y);
    public delegate double Convertor(double x);   

    class Program
    {
        static void Main(string[] args)
        {
            /*Calculator calculator = new Calculator();
            Operation oper = new Operation(calculator.Add);
                    
            oper += calculator.Div;
            oper += calculator.Multi;
            
            rez = oper.Invoke(900, 85.2);*/
            // Convertor convertor = new Convertor(ConvertorTemperature.CelcToFar);
            //  convertor += ConvertorTemperature.FarToCel;

            // convertor.Invoke(10);
            Action <double/*ConvertorTemperature*/> converAction;
            converAction = ConvertorTemperature.FarToCel;
            converAction += ConvertorTemperature.CelcToFar;
            converAction.Invoke(100);

            converAction = (x)=> { Console.WriteLine("\nConvert from FAr " + x + "C  To Kelvin=" + ((x-273) *1.8  + 32) + " Kel"); };
            converAction.Invoke(100);

            converAction = (x) => { Console.WriteLine("\n+-+-+-+-+-+-+-+-+" + x + x + "x+x" + x + "-+-+-+-+-+-+-+"); };
            converAction.Invoke(100);

            converAction = Calculator.MultiAction;
            converAction.Invoke(100);


            Console.ReadKey();

        }
    }
}
