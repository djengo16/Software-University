using System;
using System.Collections.Generic;
using System.Linq;
namespace Problem_2._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int firstLength = input[0];
            int secondLength = input[1];

            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();

            for (int i = 0; i < firstLength; i++)
            {
                int number = int.Parse(Console.ReadLine());
                first.Add(number);
            }
            for (int i = 0; i < secondLength; i++)
            {
                int number = int.Parse(Console.ReadLine());
                second.Add(number);
            }

            foreach (var num in first)
            {
                if (second.Contains(num))
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}
