using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle
{
    public abstract class Vehicle
    {
        //- tank capacity. A vehicle cannot start with or refuel above its tank capacity.

        public Vehicle(double fuelQuantity, double fuelConsumption,double fuelCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            FuelCapacity = fuelCapacity;
            
        }

        public abstract void Drive(double distance);
        

        //fuel quantity, fuel consumption in liters per km
        public double FuelCapacity { get;protected set; }
        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get;protected set; }
    }
}
