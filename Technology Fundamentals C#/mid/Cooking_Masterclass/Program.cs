using System;

namespace Cooking_Masterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            float budget = float.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            float priceForOneFloorPackage = float.Parse(Console.ReadLine());
            float priceForSingleEgg = float.Parse(Console.ReadLine());
            float priceForSingleApron = float.Parse(Console.ReadLine());

            double extraApron = Math.Ceiling(students * 0.20);
            double totalApronPrice = (extraApron + students) * priceForSingleApron;

            int freeFlourPackages = students / 5;

            double totalFlourPrice = (students - freeFlourPackages) * priceForOneFloorPackage;

            double totalEggsPrice = students * (10 * priceForSingleEgg);

            double totalPriceForAllProducts = totalApronPrice + totalEggsPrice + totalFlourPrice;

            if (totalPriceForAllProducts <= budget)
            {
                
                Console.WriteLine($"Items purchased for {totalPriceForAllProducts:F2}$.");
            }
            else
            {
                double needed = totalPriceForAllProducts - budget;
                Console.WriteLine($"{needed:F2}$ more needed.");
            }
                
        }
    }
}
