using NUnit.Framework;

namespace Tests
{
    using CarManager;
    using System;
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        // double fuelConsumption, double fuelCapacity)
        [Test]
        public void ConstructorShouldBeInitializedCorrectly()
        {
            string make = "BMW";
            string model = "e90";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void MakeShouldThrowArgumentExceptionIfItsNull()
        {
            string make = null;
            string model = "e90";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            Assert
                .Throws<ArgumentException>(()=> new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void ModelShouldThrowArgumentExceptionIfItsNull()
        {
            string make = "BMW";
            string model = null;
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            Assert
                .Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelConsumptionShouldThrowExceptionIfZero()
        {
            string make = "BMW";
            string model = "e90";
            double fuelConsumption = 0;
            double fuelCapacity = 100;

            Assert
                .Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelConsumptionShouldThrowExceptionIfNegative()
        {
            string make = "BMW";
            string model = "e90";
            double fuelConsumption = -3;
            double fuelCapacity = 100;

            Assert
                .Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelCapacityionShouldThrowExceptionIfZero()
        {
            string make = "BMW";
            string model = "e90";
            double fuelConsumption = 10;
            double fuelCapacity = 0;

            Assert
                .Throws<ArgumentException>(() =>  new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelCapacityShouldThrowExceptionIfNegative()
        {
            string make = "BMW";
            string model = "e90";
            double fuelConsumption = 10;
            double fuelCapacity = -2;

            Assert
                .Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void RefuelMethodShouldWorkCorrectly()
        {
            double fuelToRefuel = 20;
            string make = "BMW";
            string model = "e90";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);
            double expectedFuel = 20;
            double actualFuel = car.FuelAmount;

            Assert.AreEqual(expectedFuel, actualFuel);
        }
        [Test] 
        public void FuelAmountShoudStartWithZero()
        {
            string make = "BMW";
            string model = "e90";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            double actualFuelStart = car.FuelAmount;
            Assert.AreEqual(0, actualFuelStart);
        }
        [Test]
        
        public void RefuelMethodShouldThrowExceptionIfZero()
        {
            double zeroFuel = 0;
            string make = "BMW";
            string model = "e90";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(zeroFuel));
        }
        [Test]

        public void RefuelMethodShouldThrowExceptionIfNegative()
        {
            double negativeFuel = -1;
            string make = "BMW";
            string model = "e90";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(negativeFuel));
        }

        [Test]
        public void DriveMethodShouldWorkCorrectly()
        {
            //double fuelNeeded = (distance / 100) * this.FuelConsumption;
            string make = "BMW";
            string model = "e90";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(20);
            car.Drive(20);
            double actualFuelAmount = car.FuelAmount;
            double expectedFuelAmount = 19.6;
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
        [Test]
        public void DriveMethodShouldThrowExceptionIfNeededFuelIsMoreThanActual()
        {
            string make = "BMW";
            string model = "e90";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }

    }
}