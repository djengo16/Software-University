using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> uniqueElements = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();

                foreach (var current in input)
                {
                    uniqueElements.Add(current);
                }
            }
            var output = uniqueElements.OrderBy(x=>x).ToArray();
            Console.WriteLine(string.Join(" ",output));
        }
    }
}
