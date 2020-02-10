using System;

namespace Vacantion
{
    class Program
    {
        static void Main(string[] args)
        {
            int numBerOfpeople = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;
            double total = 0;
            switch (type)
            {
                case "Students":
                    if (day == "Friday")
                    {
                        price = 8.45;
                    }
                    else if (day == "Saturday")
                    {
                        price = 9.80;
                    }
                    else if (day == "Sunday")
                    {
                        price = 10.46;
                    }
                    total = numBerOfpeople * price;
                    if (numBerOfpeople >=30)
                    {
                        total = total - (total * 0.15);
                    }
                    break;
                case "Business":
                    if (day == "Friday")
                    {
                        price = 10.90;
                    }
                    else if (day == "Saturday")
                    {
                        price = 15.60;
                    }
                    else if (day == "Sunday")
                    {
                        price = 16;
                    }
                    total = numBerOfpeople * price;
                    if (numBerOfpeople >= 100)
                    {
                        total = total - (price * 10);
                    }
                    break;
                case "Regular":
                    if (day == "Friday")
                    {
                        price = 15;
                    }
                    else if (day == "Saturday")
                    {
                        price = 20;
                    }
                    else if (day == "Sunday")
                    {
                        price = 22.50;
                    }
                    total = numBerOfpeople * price;
                    if (numBerOfpeople >= 10 && numBerOfpeople <= 20)
                    {
                        total = total - (total * 0.05);
                    }
                    break;
            }
            
            Console.WriteLine($"Total price: {(total):F2}");
        }
    }
}
