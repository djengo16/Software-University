using System;

namespace Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            double result = RaiseToPower(number, power);
            Console.WriteLine(result);
        }

        static double RaiseToPower(double number,int power)
        {
            double result = number;

            for (int i = 1; i < power; i++)
            {
                result *= number;
            }

            return result;
        }
    }
}
