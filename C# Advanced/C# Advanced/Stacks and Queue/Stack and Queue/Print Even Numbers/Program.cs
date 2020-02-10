using System;
using System.Linq;
using System.Collections.Generic;
namespace Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> evenNums = new Queue<int>();

            foreach (var number in input)
            {
                if (number % 2 == 0)
                {
                    evenNums.Enqueue(number);
                }
            }
            Console.WriteLine(String.Join(", ",evenNums));

        }
    }
}
