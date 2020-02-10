using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] current = new string[2];
                bool ifExist = false;
                if (command.Contains("|"))
                {
                    current = command.Split(" | ").ToArray();
                    string forceSide = current[0];
                    string forceUser = current[1];

                    foreach (var user in data.Values)
                    {
                        if (user.Contains(forceUser))
                        {
                            ifExist = true;
                        }
                    }
                    if (!ifExist)
                    {
                        if (!data.ContainsKey(forceSide))
                        {
                            data.Add(forceSide, new List<string>());
                        }
                        data[forceSide].Add(forceUser);
                    }
                }               
                else if (command.Contains("->"))
                {
                    ifExist = false;
                    current = command.Split(" -> ").ToArray();
                    string forceSide = current[1];
                    string forceUser = current[0];
                    foreach (var user in data.Values)
                    {
                        if (user.Contains(forceUser))
                        {
                            ifExist = true;
                        }
                    }
                    if (ifExist)
                    {
                        foreach (var user in data.Values)
                        {
                            if (user.Contains(forceUser))
                            {
                                user.Remove(forceUser);
                            }
                        }
                        
                    }
                    if (!data.ContainsKey(forceSide))
                    {
                        data.Add(forceSide, new List<string>());
                    }
                    data[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }
            data = data.OrderByDescending(x => x.Value.Count).ThenBy(x=>x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var current in data.Values)
            {
                current.Sort();
            }
            foreach (var item in data)
            {
                if(item.Value.Count != 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                    item.Value.Sort();
                    foreach (var current in item.Value)
                    {
                         Console.WriteLine($"! {current}");
                    }
                }
            }
        }
    }
}
