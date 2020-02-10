using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe =
                new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                var clothes = input[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                foreach (var current in clothes)
                {
                    if (!wardrobe[color].ContainsKey(current))
                    {
                        wardrobe[color].Add(current, 0);
                    }
                    wardrobe[color][current]++;
                }
            }
            var search = Console.ReadLine().Split();
            string searchedColor = search[0];
            string searchedClothes = search[1];

            foreach (var color in wardrobe)
            {
                string currentColor = color.Key;
                Console.WriteLine($"{currentColor} clothes:");
                foreach (var clothes in color.Value)
                {
                    Console.Write($"* {clothes.Key} - {clothes.Value} ");
                    if (searchedColor == currentColor && searchedClothes == clothes.Key)
                    {
                        Console.Write("(found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
