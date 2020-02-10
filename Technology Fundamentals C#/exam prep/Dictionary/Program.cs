using System;
using System.Collections.Generic;
using System.Linq;
namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(" | ").ToList();
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();

            foreach (var current in input)
            {
                string[] currentArr = current.Split(": ").ToArray();
                string word = currentArr[0];
                string definition = currentArr[1];

                if (!dic.ContainsKey(word))
                {
                    dic.Add(word, new List<string>());
                }
                dic[word].Add(definition);
            }


            string[] wordsToPrint = Console.ReadLine().Split(" | ").ToArray();

            dic = dic.OrderBy(x=>x.Key).ToDictionary(x=>x.Key,x=>x.Value);

            for (int i = 0; i < wordsToPrint.Length; i++)
            {
                if (dic.ContainsKey(wordsToPrint[i]))
                {
                    Console.WriteLine(wordsToPrint[i]);  
                    
                    foreach (var definition in dic[wordsToPrint[i]].OrderByDescending(x=>x.Length))
                    {
                        Console.WriteLine($" -{definition}");
                    }
                }
            }

            string finalCommand = Console.ReadLine();

            if (finalCommand == "List")
            {
                Console.WriteLine(String.Join(" ",dic.Keys));
            }
        }
    }
}
