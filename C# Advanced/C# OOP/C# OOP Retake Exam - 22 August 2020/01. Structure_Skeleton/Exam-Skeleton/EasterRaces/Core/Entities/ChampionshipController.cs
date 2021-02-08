using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    class ChampionshipController : IChampionshipController
    {
        private readonly DriverRepository drivers;
        private readonly CarRepository cars;
        private readonly RaceRepository races;

        public ChampionshipController()
        {
            this.drivers = new DriverRepository();
            this.cars = new CarRepository();
            this.races = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            
            Driver driver = (Driver)drivers.GetByName(driverName);
            if(driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            Car car = (Car)cars.GetByName(carModel);
            if(car == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            }
            driver.AddCar(car);

            return String.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            Race race = (Race)races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            Driver driver = (Driver)drivers.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);
            return String.Format(OutputMessages.DriverAdded, driverName, raceName);

        }

        public string CreateCar(string type, string model, int horsePower)
        {
            
            Car car = (Car)cars.GetByName(model);
            if(car != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarExists, model));
            }
            if(type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);                
            }
            if(type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            cars.Add(car);
            return String.Format(OutputMessages.CarCreated, type, model);
        }

        public string CreateDriver(string driverName)
        {
            
            Driver driver = (Driver)drivers.GetByName(driverName);

            if(driver != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriversExists, driverName));
            }

            driver = new Driver(driverName);

            drivers.Add(driver);

            return String.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            Race race = races.GetByName(name);
            if (race != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }

            race = new Race(name, laps);
            races.Add(race);
            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            
            Race race = (Race)races.GetByName(raceName);
            if(race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if(race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName,3));
            }

            var bestDrivers = race.Drivers
                .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Driver {bestDrivers[0].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {bestDrivers[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {bestDrivers[2].Name} is third in {raceName} race.");

            return sb.ToString().TrimEnd();
        }
    }
}
