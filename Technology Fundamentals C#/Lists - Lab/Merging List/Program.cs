using System;
using System.Collections.Generic;
using System.Linq;

namespace Merging_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstValues = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> secondValues = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> finalValues = new List<int>();

            for (int i = 0; i < Math.Max(firstValues.Count,secondValues.Count); i++)
            {
                if(firstValues.Count > i)
                {
                    finalValues.Add(firstValues[i]);
                }
                if (secondValues.Count > i)
                {
                    finalValues.Add(secondValues[i]);
                }               
            }
            Console.WriteLine(String.Join(" ",finalValues));
        } 
    }
}
