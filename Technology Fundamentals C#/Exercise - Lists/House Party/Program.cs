using System;
using System.Collections.Generic;
using System.Linq;

namespace House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                switch (command[2])
                {
                    case "going!":
                        AddToGoing(command, names);
                        break;
                    case "not":
                        RemoveFromGoing(command, names);
                        break;
                }
            }
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }
        }

        private static void RemoveFromGoing(string[] command, List<string> names)
        {
            if (!names.Contains(command[0]))
            {
                Console.WriteLine($"{command[0]} is not in the list!");
            }
            else
            {
                names.Remove(command[0]);
            }
        }

        private static void AddToGoing(string[] command, List<string> names)
        {
            if (names.Contains(command[0]))
            {
                Console.WriteLine($"{command[0]} is already in the list!");
            }
            else
            {
                names.Add(command[0]);
            }
        }
    }
}
