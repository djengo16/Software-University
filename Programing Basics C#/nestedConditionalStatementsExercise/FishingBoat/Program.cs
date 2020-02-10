using System;

namespace _07.Fishing_Boat
{
    class Program
    {
        static void Main()
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberFishermen = int.Parse(Console.ReadLine());

            double price = 0;
            switch (season)
            {
                case "Spring":
                    price = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    price = 4200;
                    break;
                case "Winter":
                    price = 2600;
                    break;
            }

            if (numberFishermen <= 6)
            {
                price = price - (price * 0.10);
            }
            else if (numberFishermen > 7 && numberFishermen <= 11)
            {
                price = price - (price * 0.15);
            }
            else
            {
                price = price - (price * 0.25);
            }

            if (numberFishermen % 2 == 0 && season != "Autumn")
            {
                price = price - (price * 0.05);
            }

            if (budget < price)
            {
                Console.WriteLine($"Not enough money! You need {price - budget:f2} leva.");
            }
            else
            {
                Console.WriteLine($"Yes! You have {Math.Abs(budget - price):f2} leva left.");
            }

        }
    }
}