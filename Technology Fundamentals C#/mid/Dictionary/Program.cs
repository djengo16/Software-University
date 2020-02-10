using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> dictionary = Console.ReadLine().Split(" | ").ToList();

            dictionary.Sort();

            string[] words = Console.ReadLine().Split().ToArray();

            string command = Console.ReadLine();

            if(command == "List")
            {                
                for (int i = 0; i < dictionary.Count; i++)
                {
                    string[] dictionaryWords = dictionary[i].Split(":").ToArray();
                    Console.Write(dictionaryWords[0] + " ");
                }
            }
            else if (command == "End")
            {
                for (int i = 0; i < words.Length; i++)
                {
                    string searchedWord = words[i];
                    int checking = 0;
                    for (int y = 0; y < dictionary.Count; y++)
                    {
                        string[] dictionaryWords = dictionary[y].Split(": ").ToArray();

                        if (checking == 0 && dictionaryWords[0] == searchedWord)
                        {
                            Console.WriteLine(searchedWord);
                            checking = 1;
                        }
                        if (dictionaryWords[0] == searchedWord)
                        {
                            Console.WriteLine($"-{dictionaryWords[1]}");
                        }

                    }
                    

                }
            }

        }
    }
}
