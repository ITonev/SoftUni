using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person firstPerson;
        private Person secondPerson;
        private Person thirdPerson;

        private ExtendedDatabase.ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            this.firstPerson = new Person(123456, "Ivan");
            this.secondPerson = new Person(654321, "Pesho");
            this.thirdPerson = new Person(12312300, "Gosho");
            this.database = new ExtendedDatabase.ExtendedDatabase(firstPerson, secondPerson, thirdPerson);
        }

        [Test]
        public void PersonConstructorSetsCorrectly()
        {
            Assert.AreEqual("Ivan", firstPerson.UserName);
            Assert.AreEqual(123456, firstPerson.Id);
        }

        [Test]
        public void ConstuctorSetsCorrectly()
        {
            int expected = 3;

            Assert.AreEqual(expected, this.database.Count);
        }

        [Test]
        public void AddRangeMethodThrowsExceptionIfFull()
        {
            var people = new Person[17];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"username{i}");
            }

            Assert.Throws<ArgumentException>(() => this.database = new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void AddPersonMethodWorksCorrectly()
        {
            var expectedCount = 4;

            this.database.Add(new Person(754, "Mitko"));

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void AddPersonThrowsExceptionsIfFull()
        {
            var people = new Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"username{i}");
            }

            this.database = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(777777, "Chicho")));
        }

        [Test]
        public void AddPersonThrowsExceptionIfUserNameIsPresent()
        {
            var person = new Person(74578, "Ivan");

            Assert.Throws<InvalidOperationException>(() => this.database.Add(person), "There is already user with this username!");
        }

        [Test]
        public void AddPersonThrowsExceptionIfIdIsPresent()
        {
            var person = new Person(123456, "Peshko");

            Assert.That(() => this.database.Add(person), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void RemoveMethodWorksCorrectly()
        {
            var expectedCount = 2;

            this.database.Remove();

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void RemoveMethodThrowsExceptionIfDatabaseIsEmpty()
        {
            this.database.Remove();
            this.database.Remove();
            this.database.Remove();

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void FindByIdMethodWorksCorrectly()
        {
            var result = this.database.FindById(123456);

            Assert.AreEqual(this.firstPerson, result);
        }

        [Test]
        public void FindByIdThrowsExceptionIfIdIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-1245785));
        }

        [Test]
        public void FindByIdThrowsExceptionIfNotFound()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(9857124578));
        }

        [Test]
        public void FindByUsernameMethodWorksCorrectly()
        {
            var result = this.database.FindByUsername("Ivan");

            Assert.AreEqual(this.firstPerson, result);
        }

        [Test]
        public void FindByUsernameThrowsExceptionIfNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(null));
        }

        [Test]
        public void FindByUsernameThrowsExceptionIfNotFound()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("Goshko"));
        }

    }
}