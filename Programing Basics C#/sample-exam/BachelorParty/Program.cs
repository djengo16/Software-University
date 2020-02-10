using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachelorParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumGuest = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int guests = 0;
            int totalguests = 0;
            int money = 0;
            int moneyHave = 0;
            while (command != "The restaurant is full")
            {
                guests = int.Parse(command);
                totalguests += guests;
                if (guests < 5)
                {
                    money = guests * 100;
                }
                else
                {
                    money = guests * 70;
                }
                moneyHave += money;
                money = 0;
                command = Console.ReadLine();
            }
            if (sumGuest <= moneyHave)
            {
                int left = moneyHave - sumGuest;
                Console.WriteLine($"You have {totalguests} guests and {left} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {totalguests} guests and {moneyHave} leva income, but no singer.");
            }
        }
    }
}
