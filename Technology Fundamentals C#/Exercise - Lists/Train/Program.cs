using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> vagons = Console.ReadLine().Split().Select(int.Parse).ToList();

            int capacity = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split().ToArray();
            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    AddVagon(vagons, capacity, command);
                }
                else
                {
                    int passengers = int.Parse(command[0]);
                    for (int i = 0; i < vagons.Count; i++)
                    {
                        if (vagons[i] + passengers <= capacity)
                        {
                            vagons[i] += passengers;
                            break;
                        }
                    }
                }

                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine(String.Join(" ",vagons));
        }

        private static void AddVagon(List<int> vagons, int capacity, string[] command)
        {
            vagons.Add(int.Parse(command[1]));
        }
    }


}

