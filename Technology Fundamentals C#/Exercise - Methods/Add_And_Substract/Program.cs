using System;

namespace Add_And_Substract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstDigit = int.Parse(Console.ReadLine());
            int secondDigit = int.Parse(Console.ReadLine());
            int thirdDigit = int.Parse(Console.ReadLine());


            Operation(firstDigit, secondDigit, thirdDigit);
        }

        private static void Operation(int firstDigit, int secondDigit, int thirdDigit)
        {
            Console.WriteLine((firstDigit+secondDigit)-thirdDigit);
        }
    }
}
