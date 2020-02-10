using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEFTorrRIGHT
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse (Console.ReadLine());

            int leftSum = 0;
            int rightSum = 0;
            for (int i = 1; n >= i; i++)
            {
                int num1 = int.Parse(Console.ReadLine());
                leftSum += num1;
            }
            for (int i =1;n >= i; i++)
            {
                int num2 = int.Parse(Console.ReadLine());
                rightSum += num2;
            }
            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else if (leftSum != rightSum)
            {
                int diff = Math.Abs(leftSum - rightSum);
                Console.WriteLine($"No, diff = {diff}");
            }
        }
    }
}
