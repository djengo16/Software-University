namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //Test Part constructor

            Part part = new Part("chip", 70);

            Assert.AreEqual("chip", part.Name);
            Assert.AreEqual(70, part.Price);
        }

        [Test]

        public void TestComputerConstructor()
        {
            Computer computer = new Computer("Asus");

            Assert.AreEqual("Asus", computer.Name);
        }

        [Test]
        public void TestIfNameThrowsExceptionWhenNameIsInvalid()
        {
            Assert.Throws<ArgumentNullException>(() => new Computer(null));
        }

        [Test]

        public void TestIfTotalPriceWorksCorrectly()
        {
            Computer computer = new Computer("Asus");

            computer.AddPart(new Part("part1", 20));
            computer.AddPart(new Part("part2", 30));

            decimal totalPriceActual = computer.TotalPrice;
            decimal totalPriceExpected = 50;

            Assert.AreEqual(totalPriceExpected, totalPriceActual);
        }

        [Test]

        public void TestIfAddPartMethodWorksCorrectly()
        {
            Computer computer = new Computer("Asus");

            computer.AddPart(new Part("part1", 20));
            computer.AddPart(new Part("part2", 30));

            Assert.AreEqual(2, computer.Parts.Count);
        }

        [Test]

        public void TestIfAddPartMethodThrowsExceptionWhenPartIsNull()
        {
            Computer computer = new Computer("Asus");

            Assert.Throws<InvalidOperationException>(() => computer.AddPart(null));
        }

        [Test]

        public void TestIfRemovePartWorksCorrectly()
        {
            Computer computer = new Computer("Asus");
            Part part = new Part("part1", 20);
            Part part2 = new Part("part2", 20);
            computer.AddPart(part);


            Assert.AreEqual(true, computer.RemovePart(part));
            Assert.AreEqual(false, computer.RemovePart(part2));
            Assert.AreEqual(0, computer.Parts.Count);
        }

        [Test]
        public void TestIfGetPartReturnsPart()
        {
            Computer computer = new Computer("Asus");
            Part part = new Part("part1", 20);
            Part part2 = new Part("part2", 20);
            computer.AddPart(part);

            Assert.AreEqual(part, computer.GetPart("part1"));
            Assert.AreEqual(null, computer.GetPart("part2"));
        }
    }
}