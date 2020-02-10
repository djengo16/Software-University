using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double ownedMoney = double.Parse(Console.ReadLine());
            int counter = 0;
            int spendCounter = 0;
            while (true)
            {
                counter++;
                string command = Console.ReadLine();
                if (command == "spend")
                {
                    spendCounter++;
                    double spendMoney = double.Parse(Console.ReadLine());
                    if(spendMoney >= ownedMoney)
                    {
                        ownedMoney = 0;
                    }
                    else
                    {
                        ownedMoney -= spendMoney;
                    }
                    if (spendCounter == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(counter);
                        break;
                    }                    
                }
                else if (command=="save")
                {
                    double savedMoney = double.Parse(Console.ReadLine());
                    ownedMoney += savedMoney;
                    spendCounter = 0;
                    if (ownedMoney >= neededMoney)
                    {
                        Console.WriteLine($"You saved the money for {counter} days.");
                        break;
                    }
               }               
            }
        }
    }
}
