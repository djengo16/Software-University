using System;

namespace GiftBox_Coverage
{
    class Program
    {
        static void Main(string[] args)
        {
            float sizeOfSide = float.Parse(Console.ReadLine());
            int numberOfSheets = int.Parse(Console.ReadLine());
            float areaOfsingleSheet = float.Parse(Console.ReadLine());

            float totalArea = sizeOfSide * sizeOfSide * 6;

            double areaForThirdSheet = areaOfsingleSheet * 0.25;
            double totalAreaCovered = 0;

            for (int i = 1; i <= numberOfSheets ; i++)
            {
                if (i % 3 == 0)
                {
                    totalAreaCovered += areaForThirdSheet;
                }
                else totalAreaCovered += areaOfsingleSheet;
            }
            double percentage = (totalAreaCovered / totalArea) * 100;

            Console.WriteLine($"You can cover {percentage:F2}% of the box.");

        }
    }
}
