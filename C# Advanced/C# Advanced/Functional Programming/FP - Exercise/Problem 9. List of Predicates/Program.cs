using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_9._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> numbers = new List<int>();
            for (int i = 1; i <= range; i++)
            {
                numbers.Add(i);
            }

            Func<List<int>, List<int>> func = filter =>
          {
              List<int> filtered = new List<int>();

              foreach (var number in numbers)
              {
                  bool check = true;
                  foreach (var divider in dividers)
                  {
                      if (number % divider != 0)
                      {
                          check = false;
                      }
                  }                  
                  if (check)
                  {
                      filtered.Add(number);
                  }
              }
              return filtered;
          };

            Console.WriteLine(String.Join(" ",func(numbers)));

        }
    }
}
