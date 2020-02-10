using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{

    class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                GenerateCar(cars, input);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(p=>p.TirePressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private static void GenerateCar(List<Car> cars, string[] input)
        {
            //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType}" +
            //    " {tire1Pressure} {tire1Age} {tire2Pressure}" +
            //    " {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"

            string model = input[0];

            int engineSpeed = int.Parse(input[1]);
            int enginePower = int.Parse(input[2]);
            Engine engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(input[3]);
            string cargoTYpe = input[4];
            Cargo cargo = new Cargo(cargoTYpe, cargoWeight);


            Tire[] tires = new Tire[4];
            int counter = 0;
            for (int i = 5; i < input.Length; i+=2)
            {
                double tirePressure = double.Parse(input[i]);
                int tireAge = int.Parse(input[i + 1]);

                Tire currentTire = new Tire(tirePressure, tireAge);
                tires[counter++] = currentTire; 
            }

            Car car = new Car(model, engine, cargo, tires);
            cars.Add(car);
        }
    }
}
