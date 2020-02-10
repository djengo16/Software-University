using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            int sectors = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            double ticket = double.Parse(Console.ReadLine());

            double income = capacity * ticket; 
            double incomePerSector = income / sectors;
            double charityMoney = (income - (incomePerSector * 0.75)) / 8;

            Console.WriteLine($"Total income - {income:F2} BGN");
            Console.WriteLine($"Money for charity - {charityMoney:F2} BGN");
        }
    }
}
