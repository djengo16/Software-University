using System;

namespace Factorial_division
{
    class Program
    {
        static void Main(string[] args)
        {
            long numOne = long.Parse(Console.ReadLine());
            long numTwo = long.Parse(Console.ReadLine());

            double result = FindFactorialAndFinalResult(numOne, numTwo);
            Console.WriteLine($"{result:F2}");
        }

        private static double FindFactorialAndFinalResult(long numOne, long numTwo)
        {
            long firstFact = 1;
            long secondFact = 1;
            if (numOne != 0 && numTwo != 0)
            {
                for (long i = 1; i <= numOne; i++)
                {
                    firstFact *= i;
                }
                for (long j = 1; j <= numTwo; j++)
                {
                    secondFact *= j;
                }
                double finalResult = ((firstFact * 1.0) / secondFact);
                return finalResult;
            }
            else
            {
                return 0;
            }
        }
    }
}
