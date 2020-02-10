using System;
using System.Linq;
namespace Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            string firstNum = input[0];
            string secondNum = input[1];
            long totalSum = 0;
            if(firstNum.Length > secondNum.Length)
            {
                string bigger = firstNum;
                string smaller = secondNum;
                for (int i = 0; i < smaller.Length; i++)
                {
                    totalSum += bigger[i] * smaller[i];
                }
                for (int i = smaller.Length; i < bigger.Length; i++)
                {
                    totalSum += bigger[i];
                }
            }
            else if (secondNum.Length > firstNum.Length)
            {
                string bigger = secondNum;
                string smaller = firstNum;
                for (int i = 0; i < smaller.Length; i++)
                {
                    totalSum += bigger[i] * smaller[i];
                }
                for (int i = smaller.Length; i < bigger.Length; i++)
                {
                    totalSum += bigger[i];
                }
            }
            else
            {
                for (int i = 0; i < firstNum.Length; i++)
                {
                    totalSum += firstNum[i] * secondNum[i];
                }
            }
            Console.WriteLine(totalSum);
        }
    }
}
