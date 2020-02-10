using NUnit.Framework;

namespace Tests
{
    //using ExtendedDatabase;
    using System;
    using System.Linq;

    public class ExtendedDatabaseTests
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
        public void PersonConstructurShouldBeInitialized()
        {
            Person person = new Person(12345, "gosho");
            int expectedId = 12345;
            string expectedUsername = "gosho";
                                   
            Assert.AreEqual(expectedId, person.Id);
            Assert.AreEqual(expectedUsername, person.UserName);
        }
        [Test]
        public void ExtendedConstructorShouldBeInitialized()
        {

            Person[] persons = new Person[16];
                for (int i = 0; i < 16; i++)
                {
                    Person person = new Person(i, ("person" + i).ToString());
                    persons[i] = person;
                }
            ExtendedDatabase data = new ExtendedDatabase(persons);
            int actualcount = data.Count;
            Assert.AreEqual(16, actualcount);
        }
        [Test]
        public void AddMethodShouldAddCorectly()
        {
            Person person = new Person(12345,"gosho");
            ExtendedDatabase data = new ExtendedDatabase();

            data.Add(person);

            int expectedCount = data.Count;

            Assert.AreEqual(1, expectedCount);
        }
        [Test]
        public void AddMethodShouldNotExceed16()
        {
            ExtendedDatabase data = new ExtendedDatabase();
            for (int i = 1; i <= 16; i++)
            {
                Person person = new Person(i, ("person" + i).ToString());
                data.Add(person);
            }
            Assert.Throws<InvalidOperationException>(() => data.Add(new Person(123, "test")));
        }
        //[Test]
        //public void AddRangeMethodShouldNotExceed16()
        //{
        //    ExtendedDatabase data = new ExtendedDatabase();
        //    Person[] persons = new Person[17];
        //    for (int i = 0; i < 17; i++)
        //    {
        //        Person person = new Person(i, ("person" + i).ToString());
        //        persons[i] = person;
        //    }

        //    Assert.Throws<InvalidOperationException>(()=>data.AddRange(persons));
        //}
        //o	If there are already users with this username, InvalidOperationException is thrown.
        [Test]
        public void AddMethodShouldThrowExceptionIfPersonIdIsRepeating()
        {
            Person person = new Person(12345, "gosho");
            Person personWithSameId = new Person(12345, "ivan");
            ExtendedDatabase data = new ExtendedDatabase();

            data.Add(person);

            Assert.Throws<InvalidOperationException>(() => data.Add(personWithSameId));
        }
        [Test]
        public void AddMethodShouldThrowExceptionIfPersonUsernameIsRepeating()
        {
            Person person = new Person(123456, "gosho");
            Person personWithSameUsername = new Person(12345, "gosho");
            ExtendedDatabase data = new ExtendedDatabase();

            data.Add(person);

            Assert.Throws<InvalidOperationException>(() => data.Add(personWithSameUsername));
        }
        [Test]
        public void RemoveMethodShouldRemoveCorectly()
        {
            Person person1 = new Person(123456, "gosho");
            Person person2 = new Person(12345, "pesho");
            ExtendedDatabase data = new ExtendedDatabase();

            data.Add(person1);
            data.Add(person2);
            data.Remove();
            int actualCount = data.Count;
            Assert.AreEqual(1, actualCount);
        }
        [Test]
        public void RemoveMethodShouldRemoveTheLastPerson()
        {

            Person person1 = new Person(123456, "gosho");
            Person person2 = new Person(12345, "pesho");
            ExtendedDatabase data = new ExtendedDatabase();

            data.Add(person1);
            data.Add(person2);
            data.Remove();
            int actualCount = data.Count;
            Person expectedPerson = new Person(123456, "gosho");
            Person actualPerson = data.FindByUsername("gosho");

            Assert.AreEqual(expectedPerson, actualPerson);
        }
        [Test]
        public void RemoveMethodShouldThrowExceptionIfEmpty()
        {
            ExtendedDatabase data = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => data.Remove());
        }

            //        o If no user is present by this username, InvalidOperationException is thrown.
            //o If username parameter is null, ArgumentNullException is thrown.
            //o Arguments are all CaseSensitive.
         [Test]
         public void ShouldThrowExceptionIfNoUserIsPresentByTheGivenUsername()
        {
            Person person = new Person(12345, "gosho");
            ExtendedDatabase data = new ExtendedDatabase();

            data.Add(person);

            Assert.Throws<InvalidOperationException>(() => data.FindByUsername("ivan"));
        }
        [Test]
        public void ShoudThrowArgumentNullExceptionIfItsNull()
        {
            Person person = new Person(12345, "gosho");
            ExtendedDatabase data = new ExtendedDatabase();

            data.Add(person);

            Assert.Throws<ArgumentNullException>(() => data.FindByUsername(null));
        }

        //o If no user is present by this id, InvalidOperationException is thrown.
        //o If negative ids are found, ArgumentOutOfRangeException is thrown.
        [Test]
        public void ShouldThrowExceptionIfNoUserIsPresentByTheGivenId()
        {
            Person person = new Person(12345, "gosho");
            ExtendedDatabase data = new ExtendedDatabase();

            data.Add(person);

            Assert.Throws<InvalidOperationException>(() => data.FindById(4235));
        }
        [Test]
        public void ShouldThrowExceptionWhenIdNegative()
        {
            Person person = new Person(12345, "gosho");
            ExtendedDatabase data = new ExtendedDatabase();

            data.Add(person);

            Assert.Throws<ArgumentOutOfRangeException>(() => data.FindById(-4235));
        }

    }
}