using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanskoHotel
{
    class Program
    {
        static void Main(string[] args)
        {
            int days1 = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string opinion = Console.ReadLine();

            double sum = 0;
            int days = days1 - 1;

            

            if (room == "room for one person")
            {
                sum = days * 18;

            }
            else if (room == "apartment")
            {
                sum = days * 25;
                if (days < 10)
                {
                    sum = sum - sum * 0.30;
                }
                else if (days >= 10 && days <= 15)
                {
                    sum = sum - sum * 0.35;
                }
                else if (days > 15)
                {
                    sum = sum - sum * 0.50;
                }

            }
            else if (room == "president apartment")
            {
                sum = days * 35;
                if (days < 10)
                {
                    sum = sum - sum * 0.10;
                }
                else if (days >= 10 && days <= 15)
                {
                    sum = sum - sum * 0.15;
                }
                else if (days > 15)
                {
                    sum = sum - sum * 0.20;
                }

            }
            if (opinion == "positive")

            {
                sum = sum + sum * 0.25;
            }
            else if (opinion == "negative")
            {
                sum = sum - sum * 0.10;
            }
            Console.WriteLine($"{sum:F2}");

        }
    }
}
