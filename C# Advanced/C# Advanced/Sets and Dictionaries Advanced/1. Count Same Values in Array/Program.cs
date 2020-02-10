using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNums = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> numbers = new Dictionary<double, int>();

            foreach (var current in inputNums)
            {
                if (!numbers.ContainsKey(current))
                {
                    numbers.Add(current, 0);
                }
                numbers[current]++;
            }
            foreach (var current in numbers)
            {
                Console.WriteLine($"{current.Key} - {current.Value} times");

            }
        }
    }
}
