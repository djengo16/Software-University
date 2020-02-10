using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalogue_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] currentVehicle = input.Split().ToArray();
                Vehicle currentVeh = new Vehicle(currentVehicle[0], currentVehicle[1], currentVehicle[2],int.Parse( currentVehicle[3]));
                vehicles.Add(currentVeh);
                input = Console.ReadLine();
            }
            while((input = Console.ReadLine()) != "Close the Catalogue")
            {
                foreach (var veh in vehicles)
                {
                    if (veh.Model == input)
                    {
                        if (veh.Type == "car")
                        {
                            Console.WriteLine($"Type: Car");
                        }
                        else
                        {
                            Console.WriteLine($"Type: Truck");
                        }
                        Console.WriteLine($"Model: {veh.Model}");
                        Console.WriteLine($"Color: {veh.Color}");
                        Console.WriteLine($"Horsepower: {veh.Horsepower}");
                    }
                }
            }
            double averageHpCars = 0;
            int carCounter = 0;
            int truckCounter = 0;
            double averageHpTrucks = 0;
            foreach (var veh in vehicles)
            {
                if (veh.Type == "car")
                {
                    averageHpCars += veh.Horsepower;
                    carCounter++;
                }
                else
                {
                    averageHpTrucks += veh.Horsepower;
                    truckCounter++;
                }
            }
            if (carCounter != 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {(averageHpCars / carCounter):F2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");
            }
            if (truckCounter != 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {(averageHpTrucks / truckCounter):F2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }
        }

    }
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }

       public Vehicle(string type,string model,string color,int horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.Horsepower = horsePower;
        }
    }
}
