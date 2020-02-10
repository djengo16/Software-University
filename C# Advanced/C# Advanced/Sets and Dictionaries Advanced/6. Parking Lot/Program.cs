using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command =input.Split(", ");
                string option = command[0];
                string carNumber = command[1];

                if (option == "IN")
                {
                    cars.Add(carNumber);
                }
                else
                {
                    cars.Remove(carNumber);
                }
                
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
