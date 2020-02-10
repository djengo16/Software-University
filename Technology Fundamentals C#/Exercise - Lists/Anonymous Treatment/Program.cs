using System;
using System.Collections.Generic;
using System.Linq;

namespace Anonymous_Treatment
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToList();

            string[] command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (command[0]  != "3:1")
            {
                if (command[0] == "merge")
                {
                    MergeListMethod(input,command);
                }
                else if (command[0] == "divide")
                {
                    DivideListMethod(input, command);
                }                
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            Console.WriteLine(string.Join(" ", input));
        }

        private static void DivideListMethod(List<string> input, string[] command)
        {
            
            int index = int.Parse(command[1]);
          
            string elements = input[index];
            input.RemoveAt(index);
            
            int parpartitions = int.Parse(command[2]);
            int word = elements.Length / parpartitions;

            string[] DividedElements = new string[parpartitions];

             if (index >= 0 && index <= input.Count)
            {
                for (int i = 0; i < parpartitions; i++)
                {
                  if (i == parpartitions - 1)
                    {
                        DividedElements[i] = elements.Substring(i * word);
                    }
                  else
                    {
                        DividedElements[i] = elements.Substring(i * word, word);
                    }
                }
                input.Insert(index, String.Join(" ", DividedElements));
            }
            else
            {
                return;
            }
        }
        private static void MergeListMethod(List<string> input,string[] command)
        {
            int start = int.Parse(command[1]);
            int end = int.Parse(command[2]);

            if(end > start)
            {
                if (end > input.Count - 1)
                {
                    end = input.Count - 1;
                }
                for (int i = start; i < end; i++)
                {
                    input[start] += input[start + 1];
                    input.RemoveAt(start + 1);
                }
            }
            else
            {
                return;
            }
            
        }
    }
}
