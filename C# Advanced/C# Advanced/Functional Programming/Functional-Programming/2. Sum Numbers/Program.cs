using System;
using System.Linq;
using System.Collections.Generic;

namespace _2._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = n => int.Parse(n);
            var numbers = Console.ReadLine()
                .Split(", ")
                .Select(parser)
                .ToArray();
            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
       
        }
    }
}
