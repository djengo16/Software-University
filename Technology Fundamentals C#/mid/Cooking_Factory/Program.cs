using System;
using System.Linq;
using System.Collections.Generic;

namespace Cooking_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            int bestSum = -1000;
            double bestAverageQuality = -1000;
            int bestElements = -1000;
            List<int> bestBread = new List<int>();
            while((input = Console.ReadLine()) != "Bake It!")
            {
                List<int> currentBread = input.Split("#").Select(int.Parse).ToList();

                int currentSum = currentBread.Sum();
                double currentAverageQuality = (double)currentBread.Sum() / currentBread.Count;
                int currentElements = currentBread.Count;

                if (currentSum > bestSum)
                {
                    bestBread = currentBread;
                    bestSum = currentSum;
                    bestAverageQuality = currentAverageQuality;
                    bestElements = currentElements;
                }
                else if (currentSum == bestSum)
                {
                    if (currentAverageQuality > bestAverageQuality)
                    {
                        bestBread = currentBread;
                        bestSum = currentSum;
                        bestAverageQuality = currentAverageQuality;
                        bestElements = currentElements;
                    }
                    else if (currentAverageQuality == bestAverageQuality)
                    {
                        if (currentElements < bestElements)
                        {
                            bestBread = currentBread;
                            bestSum = currentSum;
                            bestAverageQuality = currentAverageQuality;
                            bestElements = currentElements;
                        }
                    }
                }
            }
            Console.WriteLine($"Best Batch quality: {bestBread.Sum()}");
            Console.WriteLine(String.Join(" ",bestBread));
        }
    }
}
