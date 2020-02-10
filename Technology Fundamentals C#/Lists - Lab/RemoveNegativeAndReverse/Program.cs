using System;
using System.Collections.Generic;
using System.Linq;
namespace RemoveNegativeAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = Console.ReadLine().Split().Select(int.Parse).ToList();

            var final = new List<int>();

            for (int i = 0; i < values.Count; i++)
            {
                if(values[i] >= 0)
                {
                    final.Add(values[i]);
                }
            }
            final.Reverse();
            if (final.Count > 0)
            {
                Console.WriteLine(String.Join(' ', final));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }

    }
}
