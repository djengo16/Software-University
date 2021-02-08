using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestOne()
        {
            Assert.Pass();
        }

        [Test]

        public void TestCarConstructor()
        {
            UnitCar car = new UnitCar("test", 120, 10);

            Assert.AreEqual("test", car.Model);
            Assert.AreEqual(120, car.HorsePower);
            Assert.AreEqual(10, car.CubicCentimeters);
        }

        [Test]

        public void TestUnitDriverConstructor()
        {
            UnitCar car = new UnitCar("test", 120, 10);
            UnitDriver driver = new UnitDriver("Ivan", car);

            Assert.AreEqual("Ivan", driver.Name);
            Assert.AreEqual(car, driver.Car);
        }

        [Test]
        public void TestIfThrowsExceptionWhenDriverNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitDriver(null,null));
        }


        //[Test]
        //public void TestRaceEntryConstructor()
        //{
        //    RaceEntry race = new RaceEntry();
        //    Dictionary<string, UnitDriver> driver = new Dictionary<string, UnitDriver>();
        //    Assert.AreEqual(driver, race.);
        //}

        [Test]
        public void TestRaceEntryCounter()
        {
            UnitCar car = new UnitCar("test", 120, 10);
            UnitDriver driver = new UnitDriver("Ivan", car);
            RaceEntry race = new RaceEntry();
            race.AddDriver(driver);

            int actual = race.Counter;

            Assert.AreEqual(1, actual);
        }

        [Test]

        public void TestIfAddDriverThrowsExceptionWhenDriverIsNull()
        {
            RaceEntry race = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
        }

        [Test]
        public void TestIfAddDriverThrowsExceptionWhenDriverExists()
        {
            UnitCar car = new UnitCar("test", 120, 10);
            UnitDriver driver = new UnitDriver("Ivan", car);
            RaceEntry race = new RaceEntry();
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }

        [Test]
        public void TestIfAddDriverReturnsCorrectString()
        {
            UnitCar car = new UnitCar("test", 120, 10);
            UnitDriver driver = new UnitDriver("Ivan", car);
            RaceEntry race = new RaceEntry();
           string actual =  race.AddDriver(driver);

            string expected = "Driver Ivan added in race.";

            Assert.AreEqual(expected, actual);
        }
     
        [Test]

        public void TestIfCalculateHorsePowerMethodWorksCorrect()
        {
            UnitCar car = new UnitCar("test", 120, 10);
            UnitCar car2 = new UnitCar("test2", 200, 10);
            UnitDriver driver = new UnitDriver("Ivan", car);
            UnitDriver driver2 = new UnitDriver("Gosho", car2);
            RaceEntry race = new RaceEntry();
            race.AddDriver(driver);
            race.AddDriver(driver2);

            double expected = 160.00;
            double actual = race.CalculateAverageHorsePower();

            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void TestIfCalculateHorsePowerThrowsExceptionWhenDriversAreLessThanTwo()
        {
            RaceEntry race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }

    }
}