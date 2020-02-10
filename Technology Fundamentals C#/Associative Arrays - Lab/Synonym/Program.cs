using System;
using System.Collections.Generic;
using System.Linq;
namespace Synonym
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,List <string>> words = new Dictionary<string, List<string>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!words.ContainsKey(word))
                {
                    words.Add(word, new List<string>());
                    words[word].Add(synonym);
                }
                else
                {
                    words[word].Add(synonym);
                }
            }
            foreach (var current in words)
            {
                string word = current.Key;
                var synonyms = current.Value;
                Console.WriteLine($"{word} - {String.Join(", ",synonyms)}");
            }
        }
    }
}
