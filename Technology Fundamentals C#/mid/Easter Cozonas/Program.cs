using System;

namespace Easter_Cozonas
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());

            double packOfEggsPrice = flourPrice * 0.75;
            double milkPriceForLiter = flourPrice + (flourPrice * 0.25);
            double priceForNeededMilk = milkPriceForLiter / 4;

            double priceForCozonas = flourPrice + packOfEggsPrice + priceForNeededMilk;
            int coloredEggsCounter = 0;
            int cozonasCounter = 0;

            while (budget - priceForCozonas >= 0)
            {
                budget -= priceForCozonas;
                cozonasCounter++;
                coloredEggsCounter += 3;

                if (cozonasCounter % 3 == 0)
                {
                    coloredEggsCounter -= (cozonasCounter - 2);
                }

            }
            Console.WriteLine($"You made {cozonasCounter} cozonacs! Now you have {coloredEggsCounter} eggs and {budget:F2}BGN left.");
        }
    }
}
