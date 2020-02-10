using System;

namespace Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            string[] numbersAsSplit = numbers.Split();
            double[] values = new double[numbersAsSplit.Length];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = double.Parse(numbersAsSplit[i]);
                Console.WriteLine($"{values[i]} => {Math.Round(values[i],MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
