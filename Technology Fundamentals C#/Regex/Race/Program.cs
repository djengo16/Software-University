using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(", ").ToList();
            Dictionary<string, int> racers = new Dictionary<string, int>();

            var digitPattern = @"\d";
            var letterPattern = @"[A-Za-z]";


            var input = Console.ReadLine();
            while (input != "end of race")
            {
                StringBuilder sb = new StringBuilder();
                var matchedNames = Regex.Matches(input, letterPattern);
                var matchedPoints = Regex.Matches(input, digitPattern);
                foreach (Match letter in matchedNames)
                {
                    sb.Append(letter);
                }

                int points = 0;
                foreach (Match point in matchedPoints)
                {
                    points += int.Parse(point.Value);
                }
                if (names.Contains(sb.ToString()))
                {
                    string name = sb.ToString();
                    if (!racers.ContainsKey(name))
                    {
                        racers.Add(name, points);
                    }
                    else
                    {
                        racers[name] += points;
                    }
                    
                }
               
                input = Console.ReadLine();
            }
          racers =  racers.OrderByDescending(x => x.Value).ToDictionary(x=>x.Key,x=>x.Value);
            var finalResult = racers.Keys.ToList();

            Console.WriteLine($"1st place: {finalResult[0]}");
            Console.WriteLine($"2nd place: {finalResult[1]}");
            Console.WriteLine($"3rd place: {finalResult[2]}");
         
        }
    }
}
