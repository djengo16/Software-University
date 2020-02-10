using System;
using System.Collections.Generic;
using System.Linq;

namespace Easter_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingCenters = Console.ReadLine().Split().ToList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                switch (command[0])
                {
                    case "Include":
                        IncludeOperation(shoppingCenters,command);
                        break;
                    case "Visit":
                        VisitOperation(shoppingCenters, command);
                        break;
                    case "Prefer":
                        PreferOperation(shoppingCenters, command);
                        break;
                    case"Place":
                        PlaceOperation(shoppingCenters, command);
                        break;
                }
            }
            Console.WriteLine("Shops left:");
            Console.WriteLine(String.Join(" ",shoppingCenters));
        }

        private static void PlaceOperation(List<string> shoppingCenters, string[] command)
        {
            int index = int.Parse(command[2]) + 1;
            if (index > 0 && index < shoppingCenters.Count)
            {
                shoppingCenters.Insert(index, command[1]);
            }
            else
            {
                return;
            }
        }

        private static void PreferOperation(List<string> shoppingCenters, string[] command)
        {
            int firstIndex = int.Parse(command[1]);
            int secondIndex = int.Parse(command[2]);
            if (firstIndex >= 0 && firstIndex < shoppingCenters.Count && secondIndex >= 0 && secondIndex < shoppingCenters.Count)
            {
                string firstCenter = shoppingCenters[firstIndex];
                string secondCenter = shoppingCenters[secondIndex];

                shoppingCenters.Insert(firstIndex, secondCenter);
                shoppingCenters.RemoveAt(firstIndex + 1);

                shoppingCenters.Insert(secondIndex, firstCenter);
                shoppingCenters.RemoveAt(secondIndex + 1);
            }
            else
            {
                return;
            }
        }

        private static void VisitOperation(List<string> shoppingCenters, string[] command)
        {
            int number = int.Parse(command[2]);
            if (number > shoppingCenters.Count)
            {
                return;
            }
            else
            {
                if (command[1] == "first")
                {
                    for (int i = 0; i < number; i++)
                    {
                        shoppingCenters.RemoveAt(0);
                    }
                }
                else
                {
                    for (int i = 0; i < number; i++)
                    {
                        shoppingCenters.RemoveAt(shoppingCenters.Count-1);
                    }
                }
            }
        }

        private static void IncludeOperation(List<string> shoppingCenters, string[] command)
        {
            shoppingCenters.Add(command[1]);
        }
    }
}
