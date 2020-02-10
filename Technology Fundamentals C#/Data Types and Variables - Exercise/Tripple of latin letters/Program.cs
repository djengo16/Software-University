using System;
using System.Numerics;

namespace Tripple_of_latin_letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int best = 0;
            int bestTime = 0;
                int bestSnow = 0;
                BigInteger bestValue = 0;
            int bestQuality = 0;

            for (int i = 0; i < count; i++)
            {
                int snowBallSnow = int.Parse(Console.ReadLine());
                int snowBallTime = int.Parse(Console.ReadLine());
                BigInteger snowBallQuality = BigInteger.Parse(Console.ReadLine());
                BigInteger check = snowBallSnow / snowBallTime;
                BigInteger currentValue = BigInteger.Pow((check, snowBallQuality);

                if (currentValue > bestValue)
                {
                    bestSnow = snowBallSnow; bestTime = snowBallTime; bestTime = snowBallTime; bestQuality = snowBallQuality;
                    bestValue = currentValue;
                }

            }
            Console.WriteLine($"{bestSnow} : {bestTime} = {bestValue} ({bestQuality})");

        }
    }
}
