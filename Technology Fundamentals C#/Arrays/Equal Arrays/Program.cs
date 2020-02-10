using System;
using System.Linq;

namespace Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayOne = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var arrayTwo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int diff = 0;
            int sum1 = 0;
            int sum2 = 0;
            
            for (int i = 0; i < arrayOne.Length; i++)
            {
                if (arrayOne[i] != arrayTwo[i])
                {
                    diff = i;
                    break;
                }
                else
                {
                    sum1 += arrayOne[i];
                    sum2 += arrayTwo[i];
                }
            }
            if(sum1 == sum2 && diff == 0 && sum1 != 0 && sum2 != 0)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum1}");
            }
            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {diff} index");
            }
        }
    }
}
