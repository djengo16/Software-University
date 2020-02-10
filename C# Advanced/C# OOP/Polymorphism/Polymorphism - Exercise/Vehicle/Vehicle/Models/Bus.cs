using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle
{
    public class Bus : Vehicle, IRefuelable
    {
        private const double airconditionIncrease = 1.4;


        public Bus(double fuelQuantity, double fuelConsumption, double fuelCapacity) 
            : base(fuelQuantity, fuelConsumption, fuelCapacity)
        {
            if (fuelQuantity > fuelCapacity)
            {
                base.FuelQuantity = 0;
            }
        }

        

        public bool IsEmpty { get; set; }

        public override  void Drive(double distance)
        {
            double emtyBus = this.FuelConsumption;
            double fullBuss = this.FuelConsumption + airconditionIncrease;
            double currentConsumtion = emtyBus;
            if (!IsEmpty)
            {
                currentConsumtion = fullBuss;
            }
            double neededFuel = distance * currentConsumtion;
            if (neededFuel <= this.FuelQuantity)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                this.FuelQuantity -= neededFuel;
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (fuel + this.FuelQuantity > FuelCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else
            {
                FuelQuantity += fuel;
            }
        }
    }
}
