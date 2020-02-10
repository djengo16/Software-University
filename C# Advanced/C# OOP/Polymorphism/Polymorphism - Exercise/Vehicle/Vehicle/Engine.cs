using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle
{
    public class Engine
    {
        public void StartProgram()
        {
            string command = string.Empty;

            var carInformatin = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(carInformatin[1]);
            double carFuelConsumption = double.Parse(carInformatin[2]);
            double carFuelCapacity = double.Parse(carInformatin[3]);
            Car car = new Car(carFuelQuantity, carFuelConsumption,carFuelCapacity);



            var truckInformation = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInformation[1]);
            double truckFuelConsumption = double.Parse(truckInformation[2]);
            double truckFuelCapacity = double.Parse(truckInformation[3]);
            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption,truckFuelCapacity);

            var busInformation = Console.ReadLine().Split();
            double busFuelQuantity = double.Parse(busInformation[1]);
            double busFuelConsumption = double.Parse(busInformation[2]);
            double busFuelCapacity = double.Parse(busInformation[3]);
            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busFuelCapacity);

            int count = int.Parse(Console.ReadLine());

          for(int i = 0;i < count;i++)
            {
                command = Console.ReadLine();
                var commandAsArr = command.Split();
                string currentVehicle = commandAsArr[1];
                string option = commandAsArr[0];

                switch (option)
                {
                    case "Drive":
                        double distance = double.Parse(commandAsArr[2]);
                        if (currentVehicle == "Car")
                        {
                            car.Drive(distance);
                        }
                        else if (currentVehicle == "Truck")
                        {
                            truck.Drive(distance);
                        }
                        else
                        {
                            bus.IsEmpty = false;
                            bus.Drive(distance);
                        }
                        break;
                    case "Refuel":
                        double liters = double.Parse(commandAsArr[2]);
                        if (currentVehicle == "Car")
                        {
                            car.Refuel(liters);
                        }
                        else if (currentVehicle == "Truck")
                        {
                            truck.Refuel(liters);
                        }
                        else
                        {
                            bus.Refuel(liters);
                        }
                        break;
                    case "DriveEmpty":
                        double distanceTruck = double.Parse(commandAsArr[2]);
                        bus.IsEmpty = true;
                        bus.Drive(distanceTruck);
                        break;
                }

            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
            
        }

    }
}
