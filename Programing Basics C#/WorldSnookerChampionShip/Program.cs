using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSnookerChampionShip
{
    class Program
    {
        static void Main(string[] args)
        {
            string championshipStage = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int ticketCount = int.Parse(Console.ReadLine());
            string photo = Console.ReadLine();
            double ticketPrice = 0;
            double totalPrice = 0;
            double check = 0;
            switch (championshipStage)
            {
                case "Quarter final":
                    if (ticketType == "Standard")
                    {
                        ticketPrice = 55.50;   totalPrice = ticketCount * ticketPrice; check = totalPrice;
                        if (totalPrice > 4000) totalPrice -= totalPrice * 0.25;
                        else if (totalPrice >= 2500) totalPrice -= totalPrice * 0.10;

                        if (photo == "Y" && check <= 4000) totalPrice += (40 * ticketCount);
                        Console.WriteLine($"{totalPrice:F2}");
                    }
                    else if(ticketType == "Premium")
                    {
                        ticketPrice = 105.20; totalPrice = ticketCount * ticketPrice; check = totalPrice;
                        if (totalPrice > 4000) totalPrice -= totalPrice * 0.25;
                        else if (totalPrice >= 2500) totalPrice -= totalPrice * 0.10;
                        if (photo == "Y" && check <= 4000) totalPrice += (40 * ticketCount);
                        Console.WriteLine($"{totalPrice:F2}");
                    }
                    else if (ticketType == "VIP")
                    {
                        ticketPrice = 118.90; totalPrice = ticketCount * ticketPrice; check = totalPrice;
                        if (totalPrice > 4000) totalPrice -= totalPrice * 0.25;
                        else if (totalPrice >= 2500) totalPrice -= totalPrice * 0.10;
                        if (photo == "Y" && check <= 4000) totalPrice += (40 * ticketCount);
                        Console.WriteLine($"{totalPrice:F2}");
                    }
                    break;
                case "Semi final":
                    if (ticketType == "Standard")
                    {
                        ticketPrice = 75.88; totalPrice = ticketCount * ticketPrice; check = totalPrice;
                        if (totalPrice > 4000) totalPrice -= totalPrice * 0.25;
                        else if (totalPrice >= 2500) totalPrice -= totalPrice * 0.10;
                        if (photo == "Y" &&  check <= 4000) totalPrice += (40 * ticketCount);
                        Console.WriteLine($"{totalPrice:F2}");
                    }
                    else if (ticketType == "Premium")
                    {
                        ticketPrice = 125.22; totalPrice = ticketCount * ticketPrice; check = totalPrice;
                        if (totalPrice > 4000) totalPrice -= totalPrice * 0.25;
                        else if (totalPrice >= 2500) totalPrice -= totalPrice * 0.10;
                        if (photo == "Y" && check <= 4000) totalPrice += (40 * ticketCount);
                        Console.WriteLine($"{totalPrice:F2}");
                    }
                    else if (ticketType == "VIP")
                    {
                        ticketPrice = 300.40; totalPrice = ticketCount * ticketPrice; check = totalPrice;
                        if (totalPrice > 4000) totalPrice -= totalPrice * 0.25;
                        else if (totalPrice >= 2500) totalPrice -= totalPrice * 0.10;
                        if (photo == "Y" && check <= 4000) totalPrice += (40 * ticketCount); 
                        Console.WriteLine($"{totalPrice:F2}");
                    }
                    break;
                case "Final":
                    if (ticketType == "Standard")
                    {
                        ticketPrice = 110.10; totalPrice = ticketCount * ticketPrice; check = totalPrice;
                        if (totalPrice > 4000) totalPrice -= totalPrice * 0.25;
                        else if (totalPrice >= 2500) totalPrice -= totalPrice * 0.10;
                        if (photo == "Y" && check <= 4000) totalPrice += (40 * ticketCount);
                        Console.WriteLine($"{totalPrice:F2}");
                    }
                    else if (ticketType == "Premium")
                    {
                        ticketPrice = 160.66; totalPrice = ticketCount * ticketPrice; check = totalPrice;
                        if (totalPrice > 4000) totalPrice -= totalPrice * 0.25;
                        else if (totalPrice >= 2500) totalPrice -= totalPrice * 0.10;
                        if (photo == "Y" && check <= 4000) totalPrice += (40 * ticketCount);
                        Console.WriteLine($"{totalPrice:F2}");
                    }
                    else if (ticketType == "VIP")
                    {
                        ticketPrice = 400; totalPrice = ticketCount * ticketPrice; check = totalPrice;
                        if (totalPrice > 4000) totalPrice -= totalPrice * 0.25;
                        else if (totalPrice >= 2500) totalPrice -= totalPrice * 0.10;
                        if (photo == "Y" && check <= 4000) totalPrice += (40 * ticketCount);
                        Console.WriteLine($"{totalPrice:F2}");
                    }
                    break;

            }
            
        }
    }
}
