using System;
using System.Linq;
using System.Collections.Generic;
namespace The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] operation = command.Split().ToArray();

                switch (operation[0])
                {
                    case "Delete":
                        DeleteMethod(input, operation);

                        break;
                    case "Swap":
                        SwapMethod(input, operation);
                        break;
                    case "Put":
                        PutOperaton(input, operation);
                        break;
                    case "Sort":
                        input.Sort();
                        input.Reverse();
                        break;
                    case "Replace":
                        ReplaceOperation(input, operation);
                        break;
                }
            }
            Console.WriteLine(String.Join(" ",input));
        }

        private static void ReplaceOperation(List<string> input, string[] operation)
        {
            string newItem = operation[1];

            if (input.Contains(operation[2]))
            {
                input[input.IndexOf(operation[2])] = newItem;
            }
        }

        private static void PutOperaton(List<string> input, string[] operation)
        {
            int index = int.Parse(operation[2]) - 1;
            if (index > 0 && index <= input.Count)
            {
                input.Insert(index, operation[1]);
            }
        }

        private static void SwapMethod(List<string> input, string[] operation)
        {
            string word1 = operation[1];
            string word2 = operation[2];

            if (input.Contains(word1) && input.Contains(word2))
            {
               int indexOfFirstWord = input.IndexOf(word1);
               int indexOfSecondWord = input.IndexOf(word2);

                input.Insert(indexOfFirstWord, word2);
                input.RemoveAt(indexOfFirstWord + 1);

                input.Insert(indexOfSecondWord, word1);
                input.RemoveAt(indexOfSecondWord + 1);
            }
        }

        private static void DeleteMethod(List<string> input, string[] operation)
        {
            int index = int.Parse(operation[1]);

            if (index > -1 && index + 1 < input.Count)
            {
                input.RemoveAt(index + 1);
            }
            else
            {
                return;
            }
        }

        
    }
}
