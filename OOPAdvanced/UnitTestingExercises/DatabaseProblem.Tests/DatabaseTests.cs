namespace DatabaseProblem.Tests
{
    using DatabaseProblem.Contracts;
    using NUnit.Framework;
    using DatabaseProblem.Models;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private IDatabase setUpDatabase;

        [SetUp]
        public void SetUp()
        {
            this.setUpDatabase = new Database();
            this.setUpDatabase.Add(new Person(1, "Test1"));
            this.setUpDatabase.Add(new Person(2, "Test2"));
            this.setUpDatabase.Add(new Person(3, "Test3"));
        }

        [Test]
        public void ShouldInitializeDatabaseCorrectly()
        {
            // Arrange
            IPerson[] people = new IPerson[17];

            for (int i = 0; i < 17; i++)
            {
                int id = i + 1;
                string username = $"Person{id}";
                people[i] = new Person(id, username);
            }

            // Act
            IDatabase database = new Database(people);

            // Assert
            Assert.AreEqual(people.Length, database.Count);
        }


        [Test]
        public void AddShouldThrowExceptionWhenPersonWithSameUsernameExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.setUpDatabase.Add(new Person(5, "Test1"));
            });
        }

        [Test]
        public void AddShouldThrowExceptionWhenPersonWithSameIdExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.setUpDatabase.Add(new Person(1, "Test99"));
            });
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfGivenIndexIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                IPerson person = this.setUpDatabase.FindById(0);
            });
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfGivenIndexIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                IPerson person = this.setUpDatabase.FindById(-1);
            });
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfPersonDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                IPerson person = this.setUpDatabase.FindById(99);
            });
        }

        [Test]
        public void FindByIdShouldReturnPersonWhenUsedWithValidId()
        {
            IPerson person = this.setUpDatabase.FindById(1);

            Assert.IsNotNull(person);
        }

        [Test]
        public void FindByUserNameShouldThrowExceptionIfPersonDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                IPerson person = this.setUpDatabase.FindByUsername("Test99");
            });
        }

        [Test]
        public void FindByUserNameShouldThrowExceptionIfGivenUsernameIsNullOrEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                IPerson person = this.setUpDatabase.FindByUsername("");
            });
        }

        [Test]
        public void FindByUserNameShouldReturnPersonWhenProvidedValidUserName()
        {
            IPerson person = this.setUpDatabase.FindByUsername("Test1");

            Assert.IsNotNull(person);
        }

        [Test]
        public void FindByUserNameShouldReturnCorrectPersonWhenProvidedValidUserName()
        {
            IPerson person = this.setUpDatabase.FindByUsername("Test1");

            Assert.AreEqual("Test1", person.Username);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDatabaseIsEmpty()
        {
            IDatabase database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void RemoveShouldRemoveLastAddedPerson()
        {
            IPerson person = this.setUpDatabase.Remove();

            Assert.AreEqual(3, person.Id);
            Assert.AreEqual("Test3", person.Username);
        }
    }
}
