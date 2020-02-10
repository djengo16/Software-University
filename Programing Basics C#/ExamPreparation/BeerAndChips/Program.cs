using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerAndChips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int beerBottles = int.Parse(Console.ReadLine());
            int chips = int.Parse(Console.ReadLine());

            double totalBeerPrice = beerBottles * 1.20;
            double ChipsPrice = (0.45 * totalBeerPrice); double totalChipsPrice = Math.Ceiling(ChipsPrice * chips);

            double totalPrice = totalBeerPrice + totalChipsPrice;

            if (budget >= totalPrice)
            {
                double left = budget - totalPrice;
                Console.WriteLine($"{name} bought a snack and has {left:F2} leva left.");
            }
            else
            {
                double needed = totalPrice - budget;
                Console.WriteLine($"{name} needs {needed:F2} more leva!");
            }

        }
    }
}
