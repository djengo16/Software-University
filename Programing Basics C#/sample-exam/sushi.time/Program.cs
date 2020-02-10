using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sushi.time
{
    class Program
    {
        static void Main(string[] args)
        {
            string sushi = Console.ReadLine();
            string restaurant = Console.ReadLine();
            int portions = int.Parse(Console.ReadLine());
            string order = Console.ReadLine();
            double price = 0; double totalPrice = 0;
            switch (restaurant)
            {
                case "Sushi Zone":
                    if (sushi == "sashimi")
                    {
                        price = 4.99; totalPrice = portions * price; if (order == "Y") totalPrice = totalPrice + (totalPrice * 0.2);
                        Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                    }
                    else if (sushi == "maki")
                    {
                        price = 5.29; totalPrice = portions * price; if (order == "Y") totalPrice = totalPrice + (totalPrice * 0.2);
                        Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                    }
                    else if (sushi == "uramaki")
                    {
                        price = 5.99; totalPrice = portions * price; if (order == "Y") totalPrice = totalPrice + (totalPrice * 0.2);
                        Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                    }
                    else if (sushi == "temaki")
                    {
                        price = 4.29; totalPrice = portions * price; if (order == "Y") totalPrice = totalPrice + (totalPrice * 0.2);
                        Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                    }
                    break;
                case "Sushi Time":
                    if (sushi == "sashimi")
                    {
                        price = 5.49; totalPrice = portions * price; if (order == "Y") totalPrice = totalPrice + (totalPrice * 0.2);
                        Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                    }
                    else if (sushi == "maki")
                    {
                        price = 4.69; totalPrice = portions * price; if (order == "Y") totalPrice = totalPrice + (totalPrice * 0.2);
                        Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                    }
                    else if (sushi == "uramaki")
                    {
                        price = 4.49; totalPrice = portions * price; if (order == "Y") totalPrice = totalPrice + (totalPrice * 0.2);
                        Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                    }
                    else if (sushi == "temaki")
                    {
                        price = 5.19; totalPrice = portions * price; if (order == "Y") totalPrice = totalPrice + (totalPrice * 0.2);
                        Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                    }
                    break;
                case "Sushi Bar":
                    if (sushi == "sashimi")
                    {
                        price = 5.25; totalPrice = portions * price; if (order == "Y") totalPrice = totalPrice + (totalPrice * 0.2);
                        Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                    }
                    else if (sushi == "maki")
                    {
                        price = 5.55; totalPrice = portions * price; if (order == "Y") totalPrice = totalPrice + (totalPrice * 0.2);
                        Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                    }
                    else if (sushi == "uramaki")
                    {
                        price = 6.25; totalPrice = portions * price; if (order == "Y") totalPrice = totalPrice + (totalPrice * 0.2);
                        Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                    }
                    else if (sushi == "temaki")
                    {
                        price = 4.75; totalPrice = portions * price; if (order == "Y") totalPrice = totalPrice + (totalPrice * 0.2);
                        Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                    }
                    break;
                case "Asian Pub":
                    if (sushi == "sashimi")
                    {
                        price = 4.50; totalPrice = portions * price; if (order == "Y") totalPrice = totalPrice + (totalPrice * 0.2);
                        Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                    }
                    else if (sushi == "maki")
                    {
                        price = 4.80; totalPrice = portions * price; if (order == "Y") totalPrice = totalPrice + (totalPrice * 0.2);
                        Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                    }
                    else if (sushi == "uramaki")
                    {
                        price = 5.50; totalPrice = portions * price; if (order == "Y") totalPrice = totalPrice + (totalPrice * 0.2);
                        Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                    }
                    else if (sushi == "temaki")
                    {
                        price = 5.50; totalPrice = portions * price; if (order == "Y") totalPrice = totalPrice + (totalPrice * 0.2);
                        Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                    }
                    break;
                default:
                    Console.WriteLine($"{restaurant} is invalid restaurant!");
                    break;

            }
        }
    }
}
