using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSouvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            string souvenir = Console.ReadLine();
            int souvenirCount = int.Parse(Console.ReadLine());
            double price = 0;
            switch (teamName)
            {
                case "Argentina":
                    if (souvenir == "flags")
                    {
                        price = 3.25;
                        Console.WriteLine($"Pepi bought {souvenirCount} {souvenir} of {teamName} for {(price * souvenirCount):F2} lv.");
                    }
                    else if (souvenir == "caps")
                    {
                        price = 7.20;
                        Console.WriteLine($"Pepi bought {souvenirCount} {souvenir} of {teamName} for {(price * souvenirCount):F2} lv.");
                    }
                    else if (souvenir == "posters")
                    {
                        price = 5.10;
                        Console.WriteLine($"Pepi bought {souvenirCount} {souvenir} of {teamName} for {(price * souvenirCount):F2} lv.");
                    }
                    else if (souvenir == "stickers")
                    {
                        price = 1.25;
                        Console.WriteLine($"Pepi bought {souvenirCount} {souvenir} of {teamName} for {(price * souvenirCount):F2} lv.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid stock!");
                    }
                  break;
                case "Brazil":
                    if (souvenir == "flags")
                    {
                        price = 4.20;
                        Console.WriteLine($"Pepi bought {souvenirCount} {souvenir} of {teamName} for {(price * souvenirCount):F2} lv.");
                    }
                    else if (souvenir == "caps")
                    {
                        price = 8.50;
                        Console.WriteLine($"Pepi bought {souvenirCount} {souvenir} of {teamName} for {(price * souvenirCount):F2} lv.");
                    }
                    else if (souvenir == "posters")
                    {
                        price = 5.35;
                        Console.WriteLine($"Pepi bought {souvenirCount} {souvenir} of {teamName} for {(price * souvenirCount):F2} lv.");
                    }
                    else if (souvenir == "stickers")
                    {
                        price = 1.20;
                        Console.WriteLine($"Pepi bought {souvenirCount} {souvenir} of {teamName} for {(price * souvenirCount):F2} lv.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid stock!");
                    }
                    break;
                case "Croatia":
                    if (souvenir == "flags")
                    {
                        price = 2.75;
                        Console.WriteLine($"Pepi bought {souvenirCount} {souvenir} of {teamName} for {(price * souvenirCount):F2} lv.");
                    }
                    else if (souvenir == "caps")
                    {
                        price = 6.90;
                        Console.WriteLine($"Pepi bought {souvenirCount} {souvenir} of {teamName} for {(price * souvenirCount):F2} lv.");
                    }
                    else if (souvenir == "posters")
                    {
                        price = 4.95;
                        Console.WriteLine($"Pepi bought {souvenirCount} {souvenir} of {teamName} for {(price * souvenirCount):F2} lv.");
                    }
                    else if (souvenir == "stickers")
                    {
                        price = 1.10;
                        Console.WriteLine($"Pepi bought {souvenirCount} {souvenir} of {teamName} for {(price * souvenirCount):F2} lv.");

                    }
                    else
                    {
                        Console.WriteLine("Invalid stock!");
                    }
                    break;
                case "Denmark":
                    if (souvenir == "flags")
                    {
                        price = 3.10;
                        Console.WriteLine($"Pepi bought {souvenirCount} {souvenir} of {teamName} for {(price * souvenirCount):F2} lv.");
                    }
                    else if (souvenir == "caps")
                    {
                        price = 6.50;
                        Console.WriteLine($"Pepi bought {souvenirCount} {souvenir} of {teamName} for {(price * souvenirCount):F2} lv.");
                    }
                    else if (souvenir == "posters")
                    {
                        price = 4.80;
                        Console.WriteLine($"Pepi bought {souvenirCount} {souvenir} of {teamName} for {(price * souvenirCount):F2} lv.");
                    }
                    else if (souvenir == "stickers")
                    {
                        price = 0.90;
                        Console.WriteLine($"Pepi bought {souvenirCount} {souvenir} of {teamName} for {(price * souvenirCount):F2} lv.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid stock!");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid country!");
                    break;
            }
        }
    }
}
