namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
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

        [Test]
        public void FishConstructorShouldInitializedCorrectly()
        {
            Fish fish = new Fish("nemo");
            string expectedName = "nemo";
            bool expectedAvl = true;

            Assert.AreEqual(expectedName, fish.Name);
            Assert.AreEqual(expectedAvl, fish.Available);
        }
        [Test] 
        public void AquariumConstructorShouldInitializedCorrecty()
        {
            Aquarium aquarium = new Aquarium("aqua", 3);
            string expectedName = "aqua";
            int expectedCapacity = 3;

            Assert.AreEqual(expectedName, aquarium.Name);
            Assert.AreEqual(expectedCapacity, aquarium.Capacity);
        }

        [Test]
        public void ShouldThrowExceptionIfNameIsNull()
        {
            string name = null;
            int capacity = 2;
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, capacity));
        }

        [Test]
        public void ShouldThrowExceptionIfCapacityIsBellowZero()
        {
            string name = "aqua";
            int capacity = -3;
            Assert.Throws<ArgumentException>(() => new Aquarium(name, capacity));
        }

        [Test]
        public void CountMethodShouldWorkCorrectly()
        {
            Aquarium aquarium = new Aquarium("aqua", 10);
            aquarium.Add(new Fish("nemo"));
            aquarium.Add(new Fish("ivan"));

            int expectedCount = 2;
            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void AddMethodShouldThrowException()
        {
            Aquarium aquarium = new Aquarium("aqua", 1);
            aquarium.Add(new Fish("nemo"));
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("ivan")));
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            Aquarium aquarium = new Aquarium("aqua", 10);
            aquarium.Add(new Fish("nemo"));
            aquarium.Add(new Fish("ivan"));
            aquarium.RemoveFish("ivan");
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, aquarium.Count);
        }
        [Test]
        public void RemoveMethodShouldThrowException()
        {
            Aquarium aquarium = new Aquarium("aqua", 10);
            aquarium.Add(new Fish("nemo"));
            aquarium.Add(new Fish("ivan"));
            string check = null;

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(check));
        }

        [Test]
        public void SellMethodShouldWorkCorrectly()
        {
            Fish expectedFish = new Fish("nemo");

            Aquarium aquarium = new Aquarium("aqua", 10);
            aquarium.Add(new Fish("nemo"));

            Fish realfish = aquarium.SellFish("nemo");

            Assert.AreEqual(expectedFish, realfish);

        }
            
        [Test]
        public void SellMethodShouldThrowException()
        {
            Aquarium aquarium = new Aquarium("aqua", 10);
            aquarium.Add(new Fish("nemo"));

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(null));
        }

        [Test]
        public void ReportMethodShouldWorkCorrectly()
        {
            Aquarium aquarium = new Aquarium("aqua", 10);
            aquarium.Add(new Fish("nemo"));
            aquarium.Add(new Fish("ivan"));

            //$"Fish available at {this.Name}: {fishNames}";
            string expected = $"Fish available at {aquarium.Name}: nemo, ivan";
            string real = aquarium.Report();

            Assert.AreEqual(expected, real);
        }

    }
}
