using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            var vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while ((input = Console.ReadLine()) != "Statistics")
            {
                var operation = input.Split().ToArray();
                string username = operation[0];
                if (operation[1] == "joined")
                {
                    if (!vloggers.ContainsKey(username))
                    {
                        vloggers.Add(username, new Dictionary<string, HashSet<string>>());
                        vloggers[username].Add("followed", new HashSet<string>());
                        vloggers[username].Add("followers", new HashSet<string>());
                    }
                }
                else if (operation[1] == "followed")
                {
                    string follower = operation[2];
                    vloggers[username]["followers"].Add(follower);
                    vloggers[follower]["followed"].Add(username);
                }
            }
            vloggers = vloggers.OrderByDescending(x => x.Value["followers"]
            .Count).ThenBy(x => x.Value["followed"].Count)
                .ToDictionary(x => x.Key, x => x.Value);

            int counter = 1;

            foreach (var (vlogger,people) in vloggers)
            {
                if (counter == 1)
                {
                    Console.WriteLine($"{counter}. {vlogger} : {people["followers"].Count} followers" +
                        $", {people["followed"].Count} following");
                    foreach (var current in people["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"* {current}");
                    }
                }
                else
                {
                    Console.WriteLine($"{counter}. {vlogger} : {people["followers"].Count} followers" +
                        $", {people["followed"].Count} following");
                }
                counter++;
            }

        }
    }
}
