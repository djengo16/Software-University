using System;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string money = Console.ReadLine();
            double allMoney = 0.0D;
            while (money != "Start")
            {
                double   currentMoney = double.Parse(money);

                if (currentMoney == 0.1D || currentMoney == 0.2D || currentMoney == 0.5D || currentMoney == 1.0D || currentMoney == 2.0D)
                {
                    allMoney = allMoney + currentMoney;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {currentMoney}");
                }
                money = Console.ReadLine();
            }
            string product = Console.ReadLine();
            
            
            while (product != "End")
            {
                if (product == "Nuts")
                {
                    if (allMoney >= 2.0)
                    {
                        allMoney -= 2.0;
                        Console.WriteLine("Purchased nuts");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Water")
                {
                    if (allMoney >= 0.7)
                    {
                        allMoney -= 0.7;
                        Console.WriteLine("Purchased water");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Crisps")
                {
                    if (allMoney >= 1.5)
                    {
                        allMoney -= 1.5;
                        Console.WriteLine("Purchased crisps");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");  
                    }
                }
                else if (product == "Soda")
                {
                    if (allMoney >= 0.8)
                    {
                        allMoney -= 0.8;
                        Console.WriteLine("Purchased soda");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Coke")
                {
                    if (allMoney >= 1.0)
                    {
                        allMoney -= 1.0;
                        Console.WriteLine("Purchased coke");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {allMoney:F2}");
        }
    }
}
