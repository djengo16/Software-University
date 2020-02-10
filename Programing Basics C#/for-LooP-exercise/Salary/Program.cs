using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int payment = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                if (payment > 0)
                {
                    string tabName = Console.ReadLine();
                    switch (tabName)
                    {
                        case "Facebook": payment = payment - 150; break;
                        case "Instagram": payment = payment - 100; break;
                        case "Reddit": payment = payment - 50; break;
                        default: break;
                    }
                }
                if (payment <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }
            if (payment > 0)
            {
                Console.WriteLine(payment);
            }
        }
    }
}
