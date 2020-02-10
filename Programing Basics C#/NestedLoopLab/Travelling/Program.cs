using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            double sum = 0;
            double money = 0;
            double price = 0;
            string command1 = string.Empty;
            while (destination != "End")
            {
                string command =Console.ReadLine(); if (command != "End") price = double.Parse(command); else if (command == "End") break;

                while (price > sum)
                {
                     command1 = Console.ReadLine();  if (command1 != "End") money = double.Parse(command1); else if (command1 == "End") break;
                    
                    sum += money;
                    if (sum >= price) Console.WriteLine($"Going to {destination}!");
                }
                if (command1 == "End") break;
                sum = 0;
                price = 0;
                destination = Console.ReadLine();
            }
        }
    }
}
