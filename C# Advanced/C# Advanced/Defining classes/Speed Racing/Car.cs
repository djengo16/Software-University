using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car(string model,double fuelAmount,double fuelConsumptionPerKilometer )
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }        
        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }        
        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }       
        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }

        public void Driving(string model,double distance, double consumption)
        {
            double neededFuel = distance * consumption;
            if (this.fuelAmount >= neededFuel)
            {
                this.fuelAmount -= neededFuel;
                travelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }


    }
}
