using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New.home
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int CountFlowers = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double money = 0;
            double discount = 0;

            switch (flowers)
            {
                case "Roses":
                    if (CountFlowers > 80)
                    {
                        discount = (5 * CountFlowers) * 0.10;
                        money = (5 * CountFlowers) - discount;
                    }
                    else
                    {
                        money = 5 * CountFlowers;
                    }
                    break;
                case "Dahlias":
                    if (CountFlowers > 90)
                    {
                        discount = (3.80 * CountFlowers) * 0.15;
                        money = (3.80 * CountFlowers) - discount;
                    }
                    else
                    {
                        money = 3.80 * CountFlowers;
                    }
                    break;
                case "Tulips":
                    if (CountFlowers > 80)
                    {
                        discount = (2.80 * CountFlowers) * 0.15;
                        money = (2.80 * CountFlowers) - discount;
                    }
                    else
                    {
                        money = 2.80 * CountFlowers;
                    }
                    break;
                case "Narcissus":
                    if (CountFlowers<120)
                    {
                        discount = (3 * CountFlowers) * 0.15;
                        money = (3 * CountFlowers) + discount;
                    }
                    else
                    {
                        money = 3 * CountFlowers;
                    }
                    break;
                case "Gladiolus":
                    if (CountFlowers < 80)
                    {
                        discount = (CountFlowers * 2.50) * 0.20;
                        money = (CountFlowers * 2.50) + discount;
                    }
                    else
                    {
                        money = 2.50 * CountFlowers;
                    }
                    break;
            }
            if (budget >= money)
            {
                Console.WriteLine($"Hey, you have a great garden with {CountFlowers} {flowers} and {(budget - money):F2} leva left.");
            }
            else if (budget < money)
            {
                Console.WriteLine($"Not enough money, you need {(money - budget):F2} leva more.");
            }
        }
    }
}
