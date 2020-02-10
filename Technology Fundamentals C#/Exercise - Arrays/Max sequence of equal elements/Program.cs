using System;
using System.Linq;
namespace Max_sequence_of_equal_elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int equalCounter = 0;
            int lastEqualCounter = 0;
            int maxEqualElement = 0;
            for (int i = 0; i < numbersArray.Length-1; i++)
            {

                if(numbersArray[i] == numbersArray[i + 1])
                {
                    equalCounter++;
                   // maxEqualElement = numbersArray[i];
                }
                else
                {
                  //  lastEqualCounter = equalCounter;
                    equalCounter = 0;
                }
                if(equalCounter > lastEqualCounter)
                {
                    lastEqualCounter = equalCounter;
                    maxEqualElement= numbersArray[i];
                }
            }
            for (int i = 0; i <= lastEqualCounter; i++)
            {
                Console.Write(maxEqualElement + " ");
            }
        }
    }
}
