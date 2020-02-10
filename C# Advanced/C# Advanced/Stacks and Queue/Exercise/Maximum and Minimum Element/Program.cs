using System;
using System.Linq;
using System.Collections.Generic;

namespace Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < count; i++)
            {
                int[] operation = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (operation[0] == 1)
                {
                    int number = operation[1];
                    numbers.Push(number);
                }
                else if (operation[0] == 2)
                {
                    if (numbers.Count > 0)
                    {
                        numbers.Pop();
                    }
                }
                else if (operation[0] == 3&& numbers.Count > 0)
                {
                    Console.WriteLine(numbers.Max());
                }
                else if (operation[0] == 4&& numbers.Count > 0)
                {
                    Console.WriteLine(numbers.Min());
                }
            }
                 Console.WriteLine(String.Join(", ", numbers));

        }
    }
}
