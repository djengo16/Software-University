using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Randomize_words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();

            Random rnd = new Random();

            for (int i = 0; i < words.Count; i++)
            {
                int randomIndex = rnd.Next(0, words.Count);

                string randomWord = words[randomIndex];

                words.RemoveAt(randomIndex);
                words.Insert(0, randomWord);
            }
            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}
