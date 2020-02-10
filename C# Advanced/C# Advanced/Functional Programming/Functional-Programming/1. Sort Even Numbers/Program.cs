using System;
using System.Linq;
using System.Collections.Generic;

namespace _1._Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ");

            var result = input
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToList();
            Console.WriteLine(String.Join(", ",result));
        }
    }
}
