using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string cityName = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double price = 0;

            if (cityName == "Sofia")
            {
                if (product == "coffee")
                {
                    price = 0.50 * quantity;
                    Console.WriteLine(price);
                }
                else if (product == "water")
                {
                    price = 0.80 * quantity;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    price = 1.20 * quantity;
                    Console.WriteLine( price);
                }
                else if (product == "sweets")
                {
                    price = 1.45 * quantity;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    price = 1.60 * quantity;
                    Console.WriteLine(price);
                }
            }

            else if (cityName == "Plovdiv")
            {
                if (product == "coffee")
                {
                    price = 0.40 * quantity;
                    Console.WriteLine(price);
                }
                else if (product == "water")
                {
                    price = 0.70 * quantity;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    price = 1.15 * quantity;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    price = 1.30 * quantity ;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    price = 1.50 * quantity;
                    Console.WriteLine(price);
                }
            }

            else if (cityName == "Varna")
            {
                if (product == "coffee")
                {
                    price = 0.45 * quantity;
                    Console.WriteLine(price);
                }
                else if (product == "water")
                {
                    price = 0.70 * quantity;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    price = 1.10 * quantity;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    price = 1.35 * quantity;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    price = 1.55 * quantity;
                    Console.WriteLine(price);
                }
            }
        }
    }
}
