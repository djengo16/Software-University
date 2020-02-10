using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
            int batch = int.Parse(Console.ReadLine());
            int check = 0;
            for (int i = 1; i <= batch; i++)
            {
                string product = Console.ReadLine();
                while (product == "Bake!" || product != "Bake!" && check < 5 || check >= 5)
                {
                    if (product == "flour") check += 1; else if (product == "eggs") check += 3; else if (product == "sugar") check += 1;
                                       
                    if (product == "Bake!" && check >= 5)
                    {
                        Console.WriteLine($"Baking batch number {i}...");
                        break;
                    }
                    else if (product == "Bake!" && check < 5)
                    {
                        Console.WriteLine("The batter should contain flour, eggs and sugar!");
                    }
                    product = Console.ReadLine();
                }
                check = 0;
            }

        }
    }
}
