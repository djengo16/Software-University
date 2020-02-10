using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = string.Empty;
            double price = 0;
            string type = string.Empty;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                switch (season)
                {
                    case "summer":
                        price = budget * 0.30;
                        type = "Camp";
                        break;
                    case "winter":
                        price = budget * 0.70;
                        type = "Hotel";
                        break;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";

                switch (season)
                {
                    case "summer":
                        price = budget * 0.40;
                        type = "Camp";
                        break;
                    case "winter":
                        price = budget * 0.80;
                        type = "Hotel";
                        break;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                price = budget * 0.90;
                type = "Hotel";
            }
           
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine( $"{type} - {price:F2}");
        }
    }
}
