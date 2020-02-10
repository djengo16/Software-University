using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace davideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counterDavideBy2 = 0;
            int counterDavideBy3 = 0;
            int counterDavideBy4 = 0;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    counterDavideBy2++;
                }
                if (number % 3 == 0)
                {
                    counterDavideBy3++;
                }
                if (number % 4 == 0)
                {
                    counterDavideBy4++;
                }
            }

            double percentDavideBy2 = (counterDavideBy2 * 1.0 / n) * 100;
            double percentDavideBy3 = (counterDavideBy3 * 1.0 / n) * 100;
            double percentDavideBy4 = (counterDavideBy4 * 1.0 / n) * 100;

            Console.WriteLine($"{counterDavideBy2:F2}%");
            Console.WriteLine($"{counterDavideBy3:F2}%");
            Console.WriteLine($"{counterDavideBy4:F2}%");
        }
    }
}