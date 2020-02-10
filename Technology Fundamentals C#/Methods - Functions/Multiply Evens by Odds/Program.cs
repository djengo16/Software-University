using System;

namespace Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            GetMultipleOfEvenAndOdds(number);
        }

        static void GetMultipleOfEvenAndOdds(int number)
        {
            Console.WriteLine(GetSumOfEvenDigits(number)*GetSumOfOddDigits(number));
        }

        static int GetSumOfEvenDigits(int number)
        {
            int evenSum = 0;

            while (number != 0)
            {
                int nextnum = number % 10;
                if (nextnum % 2 == 0)
                {
                    evenSum += nextnum;
                }
                number /= 10;
            }
            return evenSum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int oddSum = 0;
            while (number != 0)
            {
                int nextnum = number % 10;
                if (nextnum % 2 != 0)
                {
                    oddSum += nextnum;
                }
                number /= 10;
            }
            return oddSum;
        }
    }
}
