using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = num => num % 2 == 0;

            Action<List<int>> print = nums => Console.WriteLine(String.Join(" ",nums));

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start = input[0];
            int end = input[1];
            List<int> numbers = new List<int>();



            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }
                

            string type = Console.ReadLine();

            if(type == "even")
            {
                numbers.RemoveAll(x => !isEven(x));
            }
            else
            {
                numbers.RemoveAll(x => isEven(x));
            }
            
            print(numbers);
        }
    }
}
