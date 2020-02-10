using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divide.without.remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            
            for(int i = 1;i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number % 2 == 0) p1++;
                if (number % 3 == 0) p2++;
                if (number % 4 == 0) p3++;
            }
            double FirstPercent = p1 / n * 100;
            double SecondPercent = p2 / n * 100;
            double ThirdPercent = p3 / n * 100;
            Console.WriteLine($"{FirstPercent:F2}%");
            Console.WriteLine($"{SecondPercent:F2}%");
            Console.WriteLine($"{ThirdPercent:F2}%");
        }
    }
}
