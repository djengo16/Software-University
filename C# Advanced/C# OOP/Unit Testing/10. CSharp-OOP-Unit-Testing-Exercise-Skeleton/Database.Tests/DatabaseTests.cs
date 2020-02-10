using NUnit.Framework;
namespace Tests
{
   // using Database;
    using System;

    public class DatabaseTests
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
        public void ConstructurShouldBeInitializedWith16Elements()
        {
            int[] array = new int[16];
            Database data = new Database(array);
            int expectedCount = 16;
            int actualCount = data.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructurShouldThrowExceptionIfNotExactly16Elements()
        {
            int[] array = new int[17];
            Assert
                .Throws<InvalidOperationException>(() => new Database(array));
        }

        [Test]
        public void AddMethodShouldAddCorrectlyElementAndIncreaseTheCount()
        {
            Database data = new Database();
            data.Add(1);

            int expectedCount = 1;
            int actualCount = data.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        //[Test]
        //public void AddMethodShouldAddElementAfterTheLastOne()
        //{
        //    int[] array = { 1, 2, 3, 4, 5 };
        //    Database database = new Database(array);
        //    database.Add(6);
        //    int result = database.Fetch()[5];

        //    Assert.AreEqual(6,result);
        //}

        [Test]
        public void AddMethodShoudThrowInvalidOperationExceptionIfExceed16Elements()
        {
            int[] array = new int[16];
            Database database = new Database(array);

            Assert
                .Throws<InvalidOperationException>(() => database.Add(1));
        }

        //•	Remove operation, should support only removing an element at the last index 
        [Test]
        public void ShouldRemoveCorectlyAndDecreaseCount()
        {
            int[] array = { 1, 2, 3, 4 };
            Database database = new Database(array);

            database.Remove();

            int actualCount = database.Count;
            Assert.AreEqual(3, actualCount);
        }
        [Test]
        public void RemoveMethodShouldRemoveTheLastIndexed()
        {
            int[] array = { 1, 2, 3, 4 };
            Database database = new Database(array);

            database.Remove();

            int expectedLastElement = 3;
            int actualLastElement = database.Fetch()[2];
            Assert.AreEqual(expectedLastElement, actualLastElement);
        }
        [Test]
        public void RemoveMethodShouldThrowExceptionIfArrayEmpty()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void FetchShoudReturnAllElementsAsArray()
        {
            int[] array = { 1, 2, 4, 5 };
            Database database = new Database(array);

            int[] expectedValues = { 1, 2, 4, 5, };
            int[] actualValues = database.Fetch();

            CollectionAssert.AreEqual(expectedValues, actualValues);
        }



    }
}