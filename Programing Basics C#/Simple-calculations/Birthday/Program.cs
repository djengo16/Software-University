using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double capacity = lenght * width * height;
            double total = capacity * 0.001;
            double calculatedPercent = percent * 0.01;
            double NeededLiters = total * (1-calculatedPercent);
            Console.WriteLine("{0:F3}", NeededLiters);
        }
    }
}
