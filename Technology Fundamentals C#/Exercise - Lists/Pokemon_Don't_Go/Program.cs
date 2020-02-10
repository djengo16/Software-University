using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int lastRemoved;
            int sumOfRemovedValues = 0;

            while (sequence.Any() == true)
            {
                int index = int.Parse(Console.ReadLine());

                if(index > sequence.Count-1)
                {
                    lastRemoved = sequence[sequence.Count - 1];
                    sequence.RemoveAt(sequence.Count - 1);
                    sequence.Add(sequence[0]);
                    IncreaseOrDecreaseMethod(sequence, lastRemoved, sumOfRemovedValues);
                    sumOfRemovedValues += lastRemoved;
                }
                else if (index < 0)
                {
                    lastRemoved = sequence[0];
                    sequence.RemoveAt(0);
                    sequence.Insert(0, sequence[sequence.Count - 1]);
                    IncreaseOrDecreaseMethod(sequence, lastRemoved, sumOfRemovedValues);
                    sumOfRemovedValues += lastRemoved;
                }
                else
                {
                    lastRemoved = sequence[index];
                    sequence.RemoveAt(index);

                    IncreaseOrDecreaseMethod(sequence, lastRemoved, sumOfRemovedValues);
                    sumOfRemovedValues += lastRemoved;
                }

            }
            Console.WriteLine(sumOfRemovedValues);

          
        }
        static void IncreaseOrDecreaseMethod(List<int> sequence,int lastRemoved,int sumOfRemovedValues)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                if (lastRemoved >= sequence[i])
                {
                    sequence[i] += lastRemoved;
                }
                else
                {
                    sequence[i] -= lastRemoved;
                }
            }
        }
    }
}
