using System;
using System.Collections.Generic;
using System.Linq;

namespace Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = items => 
            Console.WriteLine(string.Join(Environment.NewLine, items));

            string[] names = Console.ReadLine()
                .Split()
                .ToArray();
                

            print(names);
        }
    }
}
