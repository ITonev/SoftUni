using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        RaceEntry race;

        [SetUp]
        public void Setup()
        {
            this.race = new RaceEntry();
        }

        [Test]
        public void ConstructorWorksCorrectly()
        {
            Assert.That(race.Counter, Is.EqualTo(0));
        }

        [Test]
        public void AddRiderWorksCorrectly()
        {
            UnitMotorcycle motorcycle = new UnitMotorcycle("Ducati", 89, 696);
            UnitRider rider = new UnitRider("Ivan", motorcycle);

            //race.AddRider(rider);

            var result = $"Rider {rider.Name} added in race.";

            Assert.AreEqual(result, race.AddRider(rider));
            Assert.AreEqual(this.race.Counter, 1);
        }

        [Test]
        public void AddRiderThrowsExceptionIfNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.race.AddRider(null));
        }

        [Test]
        public void AddRiderThrowsExceptionIfRiderExists()
        {
            UnitMotorcycle motorcycle = new UnitMotorcycle("Ducati", 89, 696);
            UnitRider rider = new UnitRider("Ivan", motorcycle);

            this.race.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => this.race.AddRider(rider));
        }

        [Test]
        public void CalculateAverageHorsePowerWorksCorrectly()
        {
            UnitMotorcycle motorcycle = new UnitMotorcycle("Honda", 109, 1000);
            UnitRider rider = new UnitRider("Mitko", motorcycle);

            UnitMotorcycle motorcycle1 = new UnitMotorcycle("BMW", 185, 1200);
            UnitRider rider1 = new UnitRider("Goshko", motorcycle1);

            UnitMotorcycle motorcycle2 = new UnitMotorcycle("Ducati", 89, 696);
            UnitRider rider2 = new UnitRider("Ivan", motorcycle2);

            this.race.AddRider(rider);
            this.race.AddRider(rider1);
            this.race.AddRider(rider2);

            double averageHorsePowers = new List<int>() { motorcycle.HorsePower, motorcycle1.HorsePower, motorcycle2.HorsePower }.Average();

            Assert.AreEqual(averageHorsePowers, this.race.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerThrowsException()
        {
            UnitMotorcycle motorcycle = new UnitMotorcycle("Ducati", 89, 696);
            UnitRider rider = new UnitRider("Ivan", motorcycle);

            this.race.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => this.race.CalculateAverageHorsePower());
        }
    }
}