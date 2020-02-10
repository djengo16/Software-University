using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holiday =int.Parse(Console.ReadLine());
            int weekendsInHomeTown = int.Parse(Console.ReadLine());

            int weekendsInSofia = 48 - weekendsInHomeTown;

            double gamesInSofia = weekendsInSofia * (3.0 / 4);
            double gamesInhometown = weekendsInHomeTown;
            double gamesInHolidays = holiday * (2.0 / 3);

            double totalGames = gamesInSofia + gamesInHolidays + gamesInhometown;

            if(year == "leap")
            {
                totalGames = totalGames + (totalGames * 0.15);
                Console.WriteLine(Math.Floor(totalGames));
            }
            else if (year == "normal")
            {
                Console.WriteLine(Math.Floor(totalGames));
            }
        }

    }
}
