using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenis_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double tenisRacketPrice = double.Parse(Console.ReadLine());
            int tenisRacketCount = int.Parse(Console.ReadLine());
            int sneakersCount = int.Parse(Console.ReadLine());

            double totalRacketPrice = tenisRacketPrice * tenisRacketCount;
            double sneakersPrice = tenisRacketPrice / 6;
            double totalSneakersPrice = sneakersPrice * sneakersCount;

            double otherEquip = (totalRacketPrice + totalSneakersPrice) * 0.2;
            double totalPrice = totalSneakersPrice + totalRacketPrice + otherEquip;

            double Djokovich = totalPrice / 8;
            double sponsors = totalPrice * 7 / 8;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(Djokovich)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(sponsors)}");
        }
    }
}
