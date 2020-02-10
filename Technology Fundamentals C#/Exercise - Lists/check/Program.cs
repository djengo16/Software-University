using System;
using System.Collections.Generic;
using System.Linq;

namespace check
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "OneTwoThree";

            // Get first three characters.
            string sub = input.Substring(1, 4);
            Console.WriteLine("Substring: {0}", sub);
            Console.WriteLine("Substring: {0}", sub);

            Console.WriteLine(8%2);
        }
    }
}
