using System;
using System.Collections.Generic;
using System.Linq;
   
namespace Count_Chars_In_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().Replace(" ",string.Empty);

            Dictionary<char, int> charCount = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];
                if (charCount.ContainsKey(letter))
                {
                    charCount[letter]++;
                }
                else
                {
                    charCount.Add(letter, 1);
                }
            }
            foreach (var letter in charCount)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}
