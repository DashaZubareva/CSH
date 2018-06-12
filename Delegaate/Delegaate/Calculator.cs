using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegaate
{
    static class Calculator
    {

        static public double Add(double x, double y)
        {
            Console.WriteLine("Add=" + (x + y));
            return x + y;
        }
        static public double Diff(double x, double y)
        {
            Console.WriteLine("Diff=" +( x - y));
            return x - y;
        }
        static public double Div(double x, double y)
        {
            Console.WriteLine("Div=" + x / y);
            return y!=0 ? x/y:0;
        }
        static public double Multi(double x, double y)
        {
            Console.WriteLine("Multi=" + x * y);
            return x * y; 
        }
        public static void  MultiAction(double x)
        {
            Console.WriteLine("\n\tMultiAction=" + x * x);
          
        }
    }
}
