using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> lenghtFunc = (name, length) => name.Length == length;
            Func<string, string, bool> startFunc = (name, pattern) => name.StartsWith(pattern);
            Func<string, string, bool> endFunc = (name, pattern) => name.EndsWith(pattern);

            var names = Console.ReadLine().Split().ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Party!")
            {
                var option = command.Split();

                if (option[0] == "Double")
                {
                    switch (option[1])
                    {
                        case "Length":
                            int length = int.Parse(option[2]);
                            var filtered = names.Where(name => lenghtFunc(name,length)).ToList();
                            names.AddRange(filtered);
                            break;
                        case "StartsWith":
                            string pattern = option[2];
                            var temp = names.Where(name => startFunc(name, pattern)).ToList();
                            break;
                        case "Endswith":
                            string @char = option[2];
                            var filter = names.Where(name => endFunc(name, @char)).ToList();

                            break;
                    }
                }
            }
        }
    }
}
