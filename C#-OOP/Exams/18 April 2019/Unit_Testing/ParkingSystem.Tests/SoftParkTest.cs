namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class SoftParkTest
    {
        SoftPark park;

        [SetUp]
        public void Setup()
        {
            park = new SoftPark();
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.AreEqual(12, this.park.Parking.Count);
        }

        [Test]
        public void ParkCarThrowsExceptionIfSpotNotFound()
        {
            Car car = new Car("Honda", "CB9999");
            Assert.Throws<ArgumentException>(() => this.park.ParkCar("e19", car));

        }

        [Test]
        public void ParkCarThrowsExceptionIfSpotIsNotEmpty()
        {
            Car car = new Car("Honda", "CB9999");

            this.park.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(() => this.park.ParkCar("A1", new Car("BMW", "SW7857")));
        }

        [Test]
        public void ParkCarThrowsExceptionIfCarAlreadyExists()
        {
            Car car = new Car("Honda", "CB9999");
            this.park.ParkCar("A1", car);

            //bool carExists = this.park.Parking.Values
            //    .Any(x => x?.RegistrationNumber == car.RegistrationNumber);

            Assert.Throws<InvalidOperationException>(() => this.park.ParkCar("C1", car));
        }

        [Test]
        public void ParkCarAddsCorrectly()
        {
            Car car = new Car("Honda", "CB9999");
            Car car2 = new Car("Hondaa", "CB999999");

            this.park.ParkCar("A1", car);

            var currentSpot = "CB9999";
            var exptectedMessage = "Car:CB999999 parked successfully!";

            Assert.AreEqual(currentSpot, this.park.Parking["A1"].RegistrationNumber);
            Assert.AreEqual(exptectedMessage, this.park.ParkCar("C1", car2));
        }

        [Test]
        public void RemoveCarRemovesCorrectly()
        {
            Car car = new Car("Honda", "CB9999");
            this.park.ParkCar("A1", car);

            var expectedMessage = "Remove car:CB9999 successfully!";
            Assert.AreEqual(expectedMessage, this.park.RemoveCar("A1", car));
        }

        [Test]
        public void RemoveCarThrowsExceptionIfSpotDoesntExist()
        {
            Car car = new Car("Honda", "CB9999");
            this.park.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(() => this.park.RemoveCar("e19", car));
        }

        [Test]
        public void RemoveCarThrowsExceptionIfCarNotFoundOnThatSpot()
        {
            Car car = new Car("Honda", "CB9999");
            this.park.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(() => this.park.RemoveCar("A1", new Car("BMW", "A4457")));
        }

    }
}