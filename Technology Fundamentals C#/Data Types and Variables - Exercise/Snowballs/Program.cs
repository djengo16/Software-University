using System;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double biggestValue = 0;
            int biggestQuality = 0;
            int biggestSnow = 0;
            int biggestTime = 0;
            for (int i = 0; i < n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                double snowballValue = snowballSnow / snowballTime;
                snowballValue = Math.Pow(snowballValue, snowballQuality);
                if (snowballValue > biggestValue)
                {
                    biggestValue = snowballValue;
                    biggestSnow = snowballSnow; biggestTime = snowballTime; biggestQuality = snowballQuality;
                }
            }
            Console.WriteLine($"{biggestSnow} : {biggestTime} = {biggestValue} ({biggestQuality})");
        }
    }
}
