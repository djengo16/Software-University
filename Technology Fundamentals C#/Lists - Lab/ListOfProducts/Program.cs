using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var values = new List<string>();
            for (int i = 0; i < count; i++)
            {
                values.Add (Console.ReadLine());
            }
            values.Sort();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i+1}.{values[i]}");
            }
        }
    }
}
