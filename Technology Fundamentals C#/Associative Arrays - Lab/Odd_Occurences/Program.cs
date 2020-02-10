using System;
using System.Linq;
using System.Collections.Generic;

namespace Odd_Occurences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();
            Dictionary<string, int> wordsDictionary = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (wordsDictionary.ContainsKey(word.ToLower()))
                {

                    wordsDictionary[word.ToLower()]++;
                }
                else
                {
                    wordsDictionary.Add(word.ToLower(), 1);
                }
            }
            foreach (var word in wordsDictionary)
            {
                if (word.Value % 2 != 0)
                {
                    Console.Write(word.Key + " ");
                }
            }

        }
    }
}
