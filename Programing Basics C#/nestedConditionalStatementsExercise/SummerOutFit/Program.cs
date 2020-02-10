using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerOutFit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            string outFit=string.Empty;
            string shoes = string.Empty;


            if (timeOfDay == "Morning")
            {
                if (degrees >= 10 && degrees <= 18)
                {
                    outFit = "Sweatshirt"; shoes = "Sneakers";
                }
                else if (  degrees > 18 && degrees <= 24 )
                {
                    outFit = "Shirt"; shoes = "Moccasins";
                }
                else if (degrees >= 25)
                {
                    outFit = "T-Shirt"; shoes = "Sandals";
                }
            }
           else if (timeOfDay == "Afternoon")
            {
                if (degrees >= 10 && degrees <= 18)
                {
                    outFit = "Shirt"; shoes = "Moccasins";
                }
                else if (degrees > 18 && degrees <= 24)
                {
                    outFit = "T-Shirt"; shoes = "Sandals";
                }
                else if (degrees >= 25)
                {
                    outFit = "Swim Suit"; shoes = "Barefoot";
                }
            }
            else if (timeOfDay == "Evening")
            {
                outFit = "Shirt";
                shoes = "Moccasins";
            }
            Console.WriteLine($"It's {degrees} degrees, get your {outFit} and {shoes}.");
            
        }
    }
}
