using System;
using System.Linq;
using System.Collections.Generic;

namespace RawData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} " +
            //    "{tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
            List<Car> cars = new List<Car>();

            for (int i = 0; i < counter; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];

                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                Engine engine = new Engine(enginePower, engineSpeed);

                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                Tire[] tires = new Tire[4];
                int count = 0;
                
                for (int tireIndex = 5; tireIndex < input.Length; tireIndex+=2)
                {
                    double tirePreasure = double.Parse(input[tireIndex]);
                    int tireAge = int.Parse(input[tireIndex + 1]);
                    Tire tire = new Tire(tireAge, tirePreasure);
                    tires[count++] = tire;
                }
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
            string option = Console.ReadLine();

            if (option == "fragile")
            {
                cars.Where(x=>x.Cargo.CargoType == "fragile" && x.Tires.Any(p=>p.TirePressure < 1))
                    .ToList()
                    .ForEach(x=>Console.WriteLine(x.Model));
            }
            else if (option == "flamable")
            {
                
                cars.Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
        }
    }
}
