using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            double heigh = double.Parse(Console.ReadLine());
            double area = side * heigh / 2;
            Console.WriteLine("{0:F2}", area);
        }
    }
}
