using System;
using System.Linq;
namespace Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var result = 0;
          if (numbers.Length == 1)
            {
                Console.WriteLine(numbers[0]);
                return;
            }
          while (numbers.Length > 1)
            {
                int[] condensed = new int[numbers.Length - 1];
                for (int i = 0; i < condensed.Length; i++)
                {
                    condensed[i] = numbers[i] + numbers[i + 1];

                }
                numbers = condensed;
                result = condensed[0];
            }
            Console.WriteLine(result);
           
        }
    }
}
