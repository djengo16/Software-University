using System;

namespace Spring_Vacantion_trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int groupOfPeople = int.Parse(Console.ReadLine());
            double fuelPricePerKm = double.Parse(Console.ReadLine());
            double foodPricePerDay = double.Parse(Console.ReadLine());
            double roomPricePerNight = double.Parse(Console.ReadLine());

            double totalFoodPrice = days * (groupOfPeople * foodPricePerDay);
            double totalHotelPrice = days * (groupOfPeople * roomPricePerNight);

            if(groupOfPeople > 10)
            {
                totalHotelPrice = totalHotelPrice - (totalHotelPrice * 0.25);
            }

            double totalExpense = totalHotelPrice + totalFoodPrice;
            
            for (int i = 1; i <= days; i++)
            {
                double travelledKm = double.Parse(Console.ReadLine());
                double currentPriceForTravel = travelledKm * fuelPricePerKm;

                totalExpense += currentPriceForTravel;
                if (i % 3 == 0 || i % 5 == 0)
                {
                    totalExpense += (totalExpense * 0.4);
                }
                else if (i % 7 == 0)
                {
                    totalExpense = totalExpense - (totalExpense / groupOfPeople);
                }

                if (budget < totalExpense)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {(totalExpense - budget):F2}$ more.");
                    return;
                }
            }
            Console.WriteLine($"You have reached the destination. You have {(budget - totalExpense):F2}$ budget left.");
        }
    }
}
