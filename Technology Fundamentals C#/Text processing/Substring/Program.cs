using System;
using System.Linq;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            string input = Console.ReadLine();

            while (input.Contains(word.ToLower()))
            {
                int index = input.IndexOf(word.ToLower());
               input = input.Remove(index, word.Length);
            }
            Console.WriteLine(input);
        }
    }
}
