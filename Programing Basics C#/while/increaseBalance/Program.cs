using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace increaseBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double balance = 0;
            int counter = 0;
            double total = 0;
            while (counter < n)
            {
                balance = double.Parse(Console.ReadLine());
                if (balance > 0)
                {
                    total += balance;
                    Console.WriteLine($"Increase: {balance:F2}");
                  }
                else
                {
                    Console.WriteLine("Invalid operation!");
                  break;
                }
                counter++;
            }
            Console.WriteLine($"Total: {total:F2}");
        }
    }
}
