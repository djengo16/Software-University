using System;
using System.Linq;
using System.Collections.Generic;

namespace Froggy_Squad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> frogs = Console.ReadLine().Split().ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                if (command[0] == "Join")
                {
                    string newFrog = command[1];
                    frogs.Add(newFrog);
                }
                else if (command[0] == "Jump")
                {
                    string name = command[1];
                    int index = int.Parse(command[2]);

                    if (index >= 0 && index < frogs.Count)
                    {
                        frogs.Insert(index, name);
                    }
                }
                else if (command[0] == "Dive")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < frogs.Count)
                    {
                        frogs.RemoveAt(index);
                    }
                }
                else if (command[0] == "First")
                {
                    int count = int.Parse(command[1]);
                    if (count > frogs.Count)
                    {
                        count = frogs.Count;
                    }
                    for (int i = 0; i < count; i++)
                    {
                        Console.Write(frogs[i] + " ");
                    }
                    Console.WriteLine();
                }
                else if (command[0] == "Last")
                {
                    int count = int.Parse(command[1]);
                    if (count > frogs.Count)
                    {
                        count = frogs.Count;
                        Console.WriteLine(String.Join(" ", frogs));
                    }
                    else
                    {
                        for (int i = frogs.Count - count; i < frogs.Count; i++)
                        {
                            Console.Write(frogs[i] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                else if (command[0] == "Print")
                {
                    if (command[1] == "Normal")
                    {
                        Console.Write("Frogs: ");
                        Console.WriteLine(String.Join(" ",frogs));
                    }
                    else if (command[1] == "Reversed")
                    {
                        frogs.Reverse();
                        Console.Write("Frogs: ");
                        Console.WriteLine(String.Join(" ",frogs));
                    }
                    break;
                }

            }

        }
    }
}
