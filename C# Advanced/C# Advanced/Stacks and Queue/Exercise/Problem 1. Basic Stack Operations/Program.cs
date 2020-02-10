using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int toPush = input[0];
            int toPop = input[1];
            int lookFor = input[2];

            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < toPush; i++)
            {
                numbers.Push(inputNumbers[i]);
            }
            for (int i = 0; i < toPop; i++)
            {
                numbers.Pop();
            }
            if (numbers.Contains(lookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numbers.Count != 0)
                {
                    Console.WriteLine(numbers.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }



        }
    }
}
