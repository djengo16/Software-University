using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int prevSum = 0;
            int sum = 0;
            int numOne = 0;
            int numTwo = 0;
            int diff = 0;
            int maxDiff = 0;
            for (int i = 1; i <= n; i++)
            {
                numOne = int.Parse(Console.ReadLine());
                numTwo = int.Parse(Console.ReadLine());
                sum = numOne + numTwo;
                if (i > 1)
                {
                    diff = Math.Abs(sum - prevSum);
                }
                if (diff > maxDiff) maxDiff = diff;
                prevSum = sum;
                sum = 0;
            }
            if (diff == 0)
            {
                Console.WriteLine($"Yes, value={prevSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
        }
    }
}
