using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split()
                .ToArray();

            Func<string, bool> filter = x => x.Length <= length;

            var filtered = names.Where(filter).ToArray();

            Action<string[]> print = items =>
            Console.WriteLine(string.Join(Environment.NewLine, items));

            print(filtered);
        }
    }
}
