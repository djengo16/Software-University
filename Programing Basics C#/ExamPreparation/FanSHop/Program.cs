using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanSHop
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int productsCount = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < productsCount; i++)
            {
                string product = Console.ReadLine();
                switch (product)
                {
                    case "hoodie":
                        sum += 30;
                        break;
                    case "keychain":
                        sum += 4;
                        break;
                    case "T-shirt":
                        sum += 20;
                        break;
                    case "flag":
                        sum += 15;
                        break;
                    case "sticker":
                        sum += 1;
                        break;
                }
            }
            if (sum <= budget)
            {
                int left = budget - sum;
                Console.WriteLine($"You bought {productsCount} items and left with {left} lv.");
            }
            else
            {
                int needed = sum - budget;
                Console.WriteLine($"Not enough money, you need {needed} more lv.");
            }
        }
    }
}
