using System;
using System.Collections.Generic;
using System.Linq;
namespace Gauss_Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            int count = input.Count;

            for (int i = 0; i < count / 2; i++)
            {
                input[i] += input[input.Count - 1];
                input.RemoveAt(input.Count - 1);
            }
            Console.WriteLine(string.Join(" ",input));
        }
    }
}
