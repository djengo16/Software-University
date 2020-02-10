using System;
using System.Linq;
using System.Collections.Generic;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            int bestSubsequence = 0;
            int bestIndex = 0;
            int bestSum = 0;
            int[] bestInput = new int[size];
            int counter = 1;
            int bestcounter = 1;
            while (command != "Clone them!") 
            {
                int[] currentInput = command.Split("!",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int currentSubsequence = 0;
                int lastSubsequence = 0;
                int currentIndex = 0;
                int currentSum = 0;
                int nextIndex = 0;

                for (int i = 0; i < currentInput.Length-1; i++)
                {
                    if(currentInput[i] == 1)
                    {
                        if (currentSubsequence == 0)
                        {
                            nextIndex = i;
                        }
                        currentSubsequence++;
                        if (currentSubsequence > lastSubsequence)
                        {
                            lastSubsequence = currentSubsequence;
                            currentIndex = nextIndex;
                        }
                    }
                    else
                    {
                        currentSubsequence = 0;
                    }
                   
                }
                for (int i = 0; i < currentInput.Length; i++)
                {
                    currentSum += currentInput[i];
                }

                if(lastSubsequence > bestSubsequence)
                {
                    bestSubsequence = lastSubsequence;
                    bestInput = currentInput;
                    bestIndex = currentIndex;
                    bestSum = currentSum;
                    bestcounter = counter;
                }
                else if (lastSubsequence>= bestSubsequence && currentIndex < bestIndex)
                {
                    bestSubsequence = lastSubsequence;
                    bestInput = currentInput;
                    bestIndex = currentIndex;
                    bestSum = currentSum;
                    bestcounter = counter;
                }
                else if (lastSubsequence >= bestSubsequence && currentIndex <= bestIndex && bestSum < currentSum)
                {
                    bestSubsequence = lastSubsequence;
                    bestInput = currentInput;
                    bestIndex = currentIndex;
                    bestSum = currentSum;
                    bestcounter = counter;
                }
                counter++;
                command = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestcounter} with sum: {bestSum}.");
            Console.WriteLine(String.Join(" ",bestInput));
        }
    }
}
