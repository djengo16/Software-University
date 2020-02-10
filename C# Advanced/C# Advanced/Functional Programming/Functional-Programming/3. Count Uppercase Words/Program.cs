using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> checker = n => n[0] == n.ToUpper()[0];
            var words = Console.ReadLine().Split(new string[] { " " },
                          StringSplitOptions.RemoveEmptyEntries)
                               .Where(checker)
                               .ToArray();
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

        }
    }
}
