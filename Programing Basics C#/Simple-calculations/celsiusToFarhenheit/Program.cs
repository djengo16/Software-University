using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celsiusToFarhenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            double celsius = double.Parse(Console.ReadLine());
            double fr = (celsius * 9) / 5 + 32;
            Console.WriteLine("{0:F2}", fr);
        }
    }
}
