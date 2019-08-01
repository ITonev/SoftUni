using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void CheckIfDummyLosesHealthWhenAttacked()
        {
            Dummy dummy = new Dummy(10, 15);

            dummy.TakeAttack(5);
            var dummyHealth = dummy.Health;

            Assert.That(dummyHealth, Is.EqualTo(5), "Dummy doesn't lose health.");
        }

        [Test]
        public void CheckIfDeadDummyThrowsExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.That(() => dummy.TakeAttack(1), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void CheckIfDeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 10);

            int exp = dummy.GiveExperience();

            Assert.That(exp, Is.EqualTo(10));
        }

        [Test]
        public void CheckIfAliveDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(3);

            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));

        }
    }
}
