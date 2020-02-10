using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < counter; i++)
            {
                //{model} {fuelAmount} {fuelConsumptionFor1km}"
                var input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionPerKilometer = double.Parse(input[2]);

                Car car = new Car(model,fuelAmount, fuelConsumptionPerKilometer);

                cars.Add(model,car);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                var currentCar = command.Split();
                string currentModel = currentCar[1];
                double currentAmountOfKm = double.Parse(currentCar[2]);
                double consumption = cars[currentModel].FuelConsumptionPerKilometer;
                cars[currentModel].Driving(currentModel, currentAmountOfKm,consumption);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:F2} {car.Value.TravelledDistance}");
            }
        }
    }
}
