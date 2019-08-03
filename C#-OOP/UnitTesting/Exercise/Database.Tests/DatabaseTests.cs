using NUnit.Framework;
//using Database;
using System;
using System.Reflection;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database database;


        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(new int[] { 1, 2 });
        }

        [Test]
        public void ConstructorSetsCorrectly()
        {
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void AddMethodWorksCorrectly()
        {
            int expected = 3;

            this.database.Add(3);

            Assert.That(expected, Is.EqualTo(this.database.Count));
        }

        [Test]
        public void AddMethodThrowsExpectionWhenFull()
        {
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }

            Assert.That(() => this.database.Add(17), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void RemoveMethodWorksCorrectly()
        {
            int expectedCount = 1;

            this.database.Remove();

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void RemoveMethodThrowsExpectionWhenFull()
        {
            for (int i = 0; i < 2; i++)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Remove(), "The collection is empty!");
        }

        [Test]
        public void FetchMethodWorksCorrectly()
        {
            var data = new int[] { 1, 2 };
            var actualArray = this.database.Fetch();
            //var databaseClass = typeof(Database); //Type.GetType("Database.Database");
            //var activatedDatabaseClass = Activator.CreateInstance(databaseClass, new int[] { 1, 2 });

            //var method = databaseClass.GetMethod("Fetch", BindingFlags.Instance | BindingFlags.Public);
            //var expectedArray = method.Invoke(activatedDatabaseClass, new object[] { });

            //var actualArray = this.database.Fetch();

            CollectionAssert.AreEqual(data, actualArray);

            //Assert.AreEqual(data, actualArray);
        }

    }
}