using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toyshop
{
    class Program
    {
        static void Main(string[] args)
        {
            double vPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int teddyBears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double moneyGet = (puzzles * 2.60) + (dolls * 3) + (teddyBears * 4.10) + (minions * 8.20) + (trucks * 2);

            int toysSold = puzzles + dolls + teddyBears + minions + trucks;
            if (toysSold >= 50)
            {
                moneyGet = moneyGet - (moneyGet * 0.25);
            }

          double  moneyLeft =  moneyGet - (moneyGet * 0.10);
            if (moneyLeft >= vPrice)
            {
                Console.WriteLine("Yes! {0:F2} lv left.",moneyLeft - vPrice);
            }
            else
            {
                Console.WriteLine("Not enough money! {0:F2} lv needed.",Math.Abs (vPrice - moneyLeft));
            }
        }
    }
}
