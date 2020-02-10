using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_3._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> FuncMin = input =>
             {
                 int minNumber = int.MaxValue;
                 foreach (var number in input)
                 {
                     if (number < minNumber)
                     {
                         minNumber = number;
                     }
                 }
                 return minNumber;
             };
            int[] inputNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine( FuncMin(inputNums));
        }
    }
}
