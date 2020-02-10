using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seaTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            double foodMoneyPerDay = double.Parse(Console.ReadLine());
            double souvenirMoneyPerDay = double.Parse(Console.ReadLine());
            double hotelMoneyPerDay = double.Parse(Console.ReadLine());

            //double fuel = 420 / 100 * 7;
            double fuelMoney = 29.4 * 1.85;

            double MoneyFoodSouvenir = 3 * foodMoneyPerDay + 3 * souvenirMoneyPerDay;

            double firstday = hotelMoneyPerDay * 0.9;
            double secondday = hotelMoneyPerDay * 0.85;
            double thirdday = hotelMoneyPerDay * 0.8;

            double total = fuelMoney + MoneyFoodSouvenir + firstday + secondday + thirdday;
            Console.WriteLine($"Money needed: {total:F2}");

        }
    }
}
