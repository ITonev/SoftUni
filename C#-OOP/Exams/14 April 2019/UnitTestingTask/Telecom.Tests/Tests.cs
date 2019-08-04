namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone("Nokia", "P30");
        }

        [Test]
        public void ConstructorInitializeCorrectly()
        {
            var expectedMake = "Nokia";
            var expectedModel = "P30";

            Assert.AreEqual(expectedMake, this.phone.Make);
            Assert.AreEqual(expectedModel, this.phone.Model);
            Assert.AreEqual(0, this.phone.Count);
        }

        [Test]
        public void MakeThrowsExceptionIfEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Phone("", "P45"));
            //Assert.That(() => new Phone("", "P45"), Throws.ArgumentException.With.Message.EqualTo($"Invalid {nameof(this.phone.Make)}!"));
        }

        [Test]
        public void InvalidModelThrowsExceptionIfEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Nokia", ""));

            //Assert.That(() => new Phone("Nokia", ""), Throws.ArgumentException.With.Message.EqualTo($"Invalid {nameof(this.phone.Model)}!"));
        }

        [Test]
        public void AddContactMethodWorksCorrectly()
        {
            this.phone.AddContact("Mitko", "359888");

            Assert.AreEqual(1, this.phone.Count);
        }

        [Test]
        public void AddContactThrowsExceptionIfContactIsPresent()
        {
            this.phone.AddContact("Mitko", "359888");

            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact("Mitko", "359888"));
        }

        [Test]
        public void CallMethodWorksCorrectly()
        {
            this.phone.AddContact("Mitko", "359888");

            var expectedString = $"Calling Mitko - 359888...";

            Assert.AreEqual(expectedString, this.phone.Call("Mitko"));
        }

        [Test]
        public void CallMethodThrowsExceptionIfContactIsNotPresent()
        {
            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Goshko"));
        }
    }
}