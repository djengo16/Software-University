using System;
using System.Collections.Generic;
using System.Linq;

namespace Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> dictionary =
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < count; i++)
            {
                var data = Console.ReadLine().Split();
                string continent = data[0];
                string country = data[1];
                string city = data[2];

                if (!dictionary.ContainsKey(continent))
                {
                    dictionary.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!dictionary[continent].ContainsKey(country))
                {
                    dictionary[continent].Add(country, new List<string>());
                }
                dictionary[continent][country].Add(city);
            }
            foreach (var currentContinent in dictionary)
            {
                Console.WriteLine(currentContinent.Key + ":");
                foreach (var currentCountry in currentContinent.Value)
                {
                    Console.WriteLine($"{currentCountry.Key} -> {string.Join(", ",currentCountry.Value)}");
                }
            }
        }
    }
}
