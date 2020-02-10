using System;
using System.Collections.Generic;
using System.Linq;

namespace Hello__France
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split("|").ToList();
            double budget = double.Parse(Console.ReadLine());
            List<double> newPricesOfItems = new List<double>();
            double budgetKeep = budget;

            for (int i = 0; i < items.Count; i++)
            {
                string[] currentItemAndPrice = items[i].Split("->").ToArray();
                string itemName = currentItemAndPrice[0];
                double itemPrice = double.Parse(currentItemAndPrice[1]);

                switch (itemName)
                {
                    case "Clothes":
                        if (itemPrice > 50.00)
                        {
                            break;
                        }
                        else if (budget - itemPrice >= 0)
                        {
                            newPricesOfItems.Add(itemPrice);
                            budget -= itemPrice;
                        }

                        break;
                    case "Shoes":
                        if (itemPrice > 35.00)
                        {
                            break;
                        }
                        else if (budget - itemPrice >= 0)
                        {
                            newPricesOfItems.Add(itemPrice);
                            budget -= itemPrice;
                        }
                        break;
                    case "Accessories":
                        if (itemPrice > 20.50)
                        {
                            break;
                        }
                        else if (budget - itemPrice >= 0)
                        {
                            newPricesOfItems.Add(itemPrice);
                            budget -= itemPrice;
                        }
                        break;
                }

            }
            double oldPrice = newPricesOfItems.Sum();
            for (int i = 0; i < newPricesOfItems.Count; i++)
            {
                newPricesOfItems[i] += (newPricesOfItems[i] * 0.4);
            }
            for (int i = 0; i < newPricesOfItems.Count; i++)
            {
                Console.Write($"{newPricesOfItems[i]:F2} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Profit: {(newPricesOfItems.Sum() - oldPrice):F2}");
            if (newPricesOfItems.Sum()+ budget >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
