using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Paid")
                {
                    foreach (var name in names)
                    {
                        Console.WriteLine(name);
                    }
                    names.Clear();
                }
                else
                {
                    names.Enqueue(command);
                }
            }
            Console.WriteLine($"{names.Count} people remaining.");

        }
    }
}
