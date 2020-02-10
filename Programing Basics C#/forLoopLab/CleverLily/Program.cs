using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int lilyAge = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            int toysPrice = int.Parse(Console.ReadLine());

            double savedMoney = 0;
            int birthDayMoney = 10;

            for(int i = 1; i <= lilyAge; i++)
            {
                if (i % 2 == 0)
                {
                    savedMoney += birthDayMoney; // sum
                    birthDayMoney += 10; // ++10 for next even age
                    savedMoney -= 1;  // brother
                }
                else
                {
                    savedMoney += toysPrice;
                }                                        
            }
            if (price <= savedMoney)
            {
                double left = savedMoney - price;
                Console.WriteLine($"Yes! {left:F2}");
            }
            else
            {
                double needed = price - savedMoney;
                Console.WriteLine($"No! {needed:F2}");
            }
        }
    }
}
