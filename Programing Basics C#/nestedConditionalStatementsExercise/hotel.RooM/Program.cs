using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.RooM
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double pricePerNightApartment = 0;
            double pricePerNightStudio = 0;
            double totalPriceApartment = 0;
            double totalPriceStudio = 0;

            //double discount = 0;

            switch (month)
            {
                case "May":
                    pricePerNightApartment = 65;
                    pricePerNightStudio = 50;
                    break;
                case "October":
                    pricePerNightApartment = 65;
                    pricePerNightStudio = 50;
                    break;
                case "June":
                    pricePerNightApartment = 68.70;
                    pricePerNightStudio = 75.20;
                    break;
                case "September":
                    pricePerNightApartment = 68.70;
                    pricePerNightStudio = 75.20;
                    break;
                case "July":
                    pricePerNightApartment = 77;
                    pricePerNightStudio = 76;
                    break;
                case "August":
                    pricePerNightApartment = 77;
                    pricePerNightStudio = 76;
                    break;
            }
            totalPriceStudio = pricePerNightStudio * nights;
            if (month == "May" || month == "October")
            {
                if (nights > 7 && nights <= 14)
                {
                    totalPriceStudio = totalPriceStudio - (totalPriceStudio * 0.05);
                }
                else if (nights > 14)
                {
                    totalPriceStudio = totalPriceStudio - (totalPriceStudio * 0.30);
                }
            }
            else if (month == "June" || month == "September")
            {
                if (nights > 14)
                {
                    totalPriceStudio = totalPriceStudio - (totalPriceStudio * 0.20);
                }
            }
            totalPriceApartment = nights * pricePerNightApartment;
             if(nights > 14)
            {
                totalPriceApartment = totalPriceApartment - (totalPriceApartment * 0.10);
            }
            Console.WriteLine($"Apartment: {totalPriceApartment:F2} lv.");
            Console.WriteLine($"Studio: {totalPriceStudio:F2} lv.");

        }
    }
}
