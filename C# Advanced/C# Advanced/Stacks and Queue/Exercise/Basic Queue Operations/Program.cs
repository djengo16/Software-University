using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queueOfNums = new Queue<int>();

            int toEnqueue = numbers[0];
            int toDequeue = numbers[1];
            int numToCheck = numbers[2];

            int[] numbersToEnqueue = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < toEnqueue; i++)
            {
                queueOfNums.Enqueue(numbersToEnqueue[i]);
            }
            for (int i = 0; i < toDequeue; i++)
            {
                queueOfNums.Dequeue();
            }
            if (queueOfNums.Contains(numToCheck))
            {
                Console.WriteLine("true");
            }
            else if (queueOfNums.Count > 0)
            {
                Console.WriteLine(queueOfNums.Min());
            }
            else
            {
                Console.WriteLine(0);
            }

        }
    }
}
