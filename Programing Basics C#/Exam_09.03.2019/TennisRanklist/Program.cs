using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournirsCount = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());
            int points = startingPoints;
            int counterWins = 0;
            for (int i = 0; i < tournirsCount; i++)
            {
                string tournir = Console.ReadLine();
                if (tournir == "W")
                {
                    points += 2000;
                    counterWins++;
                }
                else if (tournir == "F")
                {
                    points += 1200;
                }
                else if (tournir == "SF")
                {
                    points += 720;
                }
            }
            double averagePoints = (points - startingPoints) / tournirsCount;
            double percentOfWins = 1.0 * counterWins / tournirsCount;
            percentOfWins *= 100;
            Console.WriteLine($"Final points: {points}");
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{percentOfWins:F2}%");
        }
    }
}
