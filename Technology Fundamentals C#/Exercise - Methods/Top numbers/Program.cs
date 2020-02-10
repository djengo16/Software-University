using System;

namespace Top_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeInput = int.Parse(Console.ReadLine());

            TopNumberFinder(sizeInput);
        }

        private static void TopNumberFinder(int sizeInput)
        {
            for (int i = 1; i <= sizeInput ; i++)
            {
                string numChecker = i.ToString();
                int numSum = 0;
                bool checkOdd = false;
                bool checkIfDivisible = false;

                for (int j = 0; j < numChecker.Length; j++)
                {
                    numSum += (int)numChecker[j];
                    if (numChecker[j] % 2 != 0)
                    {
                        checkOdd = true;
                    }
                }
                if (numSum % 8 == 0)
                {
                    checkIfDivisible = true;
                }
                if(checkIfDivisible && checkOdd)
                {
                    Console.WriteLine(i);
                }

            }
        }
    }
}
