using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    class Program
    {
        static void Main(string[] args)
        {

            string projection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            double income = 0;

            if (projection == "Premiere")
            {
                income = (rows * columns) * 12;
            }
            else if (projection == "Normal")
            {
                income = (rows * columns) * 7.50;
            }
            else if (projection == "Discount")
            {
                income = (rows * columns) * 5;
            }
            Console.WriteLine($"{income:F2} leva ");

        }
    }
}
