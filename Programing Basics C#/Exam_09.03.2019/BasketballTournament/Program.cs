using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int losesCounter = 0; int winCounter = 0;

            while (command != "End of tournaments")
            {
                string tournirName = command;
                int matches = int.Parse(Console.ReadLine());

                for (int n = 1;n <= matches; n++)
                {
                    int desiTeamPoints = int.Parse(Console.ReadLine());
                    int otherTeamPoints = int.Parse(Console.ReadLine());
                    if (desiTeamPoints > otherTeamPoints)
                    {
                        Console.WriteLine($"Game {n} of tournament {tournirName}: win with {desiTeamPoints-otherTeamPoints} points.");
                        winCounter++;
                    }
                    else if (desiTeamPoints < otherTeamPoints)
                    {
                        Console.WriteLine($"Game {n} of tournament {tournirName}: lost with {otherTeamPoints-desiTeamPoints} points.");
                        losesCounter++;
                    }
                }
                command = Console.ReadLine();
            }
            double total = losesCounter + winCounter;
            double winningPercent = (winCounter / total) * 100;
            double losesPercent = (losesCounter / total) * 100;
            Console.WriteLine($"{winningPercent:F2}% matches win");
            Console.WriteLine($"{losesPercent:F2}% matches lost");
        }
    }
}
