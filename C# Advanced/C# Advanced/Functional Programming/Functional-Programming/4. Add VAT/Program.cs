using System;
using System.Collections.Generic;
using System.Linq;
namespace _4._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().
                Split(", ")
                .Select(double.Parse)
                .Select(x => x * 1.20)
                .ToArray();

            foreach (var price in input)
            {
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
