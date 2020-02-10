using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle
{
    public class Truck : Vehicle,IRefuelable
    {
        public static double airconditionIncrease = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption,double fuelCapacity)
            : base(fuelQuantity, fuelConsumption,fuelCapacity)
        {
            this.FuelConsumption += airconditionIncrease;
            if (fuelQuantity > fuelCapacity)
            {
                base.FuelQuantity = 0;
            }

        }

        public override void Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;
            if (neededFuel <= this.FuelQuantity)
            {
                Console.WriteLine($"Truck travelled {distance} km");
                this.FuelQuantity -= neededFuel;
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (fuel+this.FuelQuantity > FuelCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else
            {
                FuelQuantity += fuel * 0.95;
            }
        }
    }
}
