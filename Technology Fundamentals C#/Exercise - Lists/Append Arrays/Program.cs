using System;
using System.Collections.Generic;
using System.Linq;

namespace Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var allValues = Console.ReadLine().Split("|",StringSplitOptions.RemoveEmptyEntries).ToList();
            allValues.Reverse();
            string keepValues = string.Empty;
            List<char> final = new List<char>();
            for (int i = 0; i < allValues.Count; i++)
            {
                final.AddRange(allValues[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToList());
            }
            List<int> finall = new List<int>();
            for (int i = 0; i < final.Count; i++)
            {
                if (char.IsDigit(final[i]) == true)
                {
                    finall.Add((int)(final[i]) - '0');
                }
            }
            Console.WriteLine(String.Join(" ",finall));
        }
    }
}
