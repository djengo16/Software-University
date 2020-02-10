using System;
using System.Linq;
using System.Collections.Generic;

namespace Bread_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> orders = Console.ReadLine().Split("|").ToList();
            int energy = 100;
            int coins = 100;
            bool outOfMoney = false;
            for (int i = 0; i < orders.Count; i++)
            {
                string[] currentOrder = orders[i].Split("-").ToArray();
                
                switch (currentOrder[0])
                {
                    case "rest":
                        int gainedEnergy = int.Parse(currentOrder[1]);
                        if (energy < 100)
                        {
                            int energy1 = 100 - energy;
                            energy += gainedEnergy;
                            if (energy > 100)
                            {
                                gainedEnergy = energy1;
                                energy = 100;
                            }
                        }
                        else
                        {
                            gainedEnergy = 0;
                        }
                        Console.WriteLine($"You gained {gainedEnergy} energy.");
                        Console.WriteLine($"Current energy: {energy}.");
                        break;
                    case "order":
                        int earnedCoins = int.Parse(currentOrder[1]);
                        
                        if (energy - 30 < 0)
                        {
                            Console.WriteLine("You had to rest!");
                            energy += 50;
                            if (energy > 100)
                            {
                                energy = 100;
                            }
                            
                        }
                        else
                        {
                            coins += earnedCoins;
                            energy -= 30;
                            Console.WriteLine($"You earned {earnedCoins} coins.");

                        }
                        break;
                    default:

                        string product = currentOrder[0];
                        int price = int.Parse(currentOrder[1]);

                        if (coins - price <= 0)
                        {
                            Console.WriteLine($"Closed! Cannot afford {product}.");
                            outOfMoney = true;
                            return;
                        }
                        else
                        {
                            coins -= price;
                            Console.WriteLine($"You bought {product}.");
                        }
                        break;
                        
                }
                if (outOfMoney == true)
                {
                    break;
                }
            }
            if (!outOfMoney)
            {
                Console.WriteLine("Day completed!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Energy: {energy}");
            }
        }      
    }
}
