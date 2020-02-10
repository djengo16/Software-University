using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wedding_Seats
{
    class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int places = int.Parse(Console.ReadLine());
            places += 97;

            for (char sector = 'A'; sector <= lastSector; sector++)
            {
                for (int row = 1; row <= rows; row++)
                {
                    if (row % 2 == 0) places += 2;
                    for (int place = 97; place <= places; place++)
                    {
                        Console.WriteLine($"{sector}{row}{(char)place}");
                    }
                }
                
            }
        }
    }
}
