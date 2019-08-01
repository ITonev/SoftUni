using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            this.axe = new Axe(10, 25);
            this.dummy = new Dummy(15, 20);

        }

        [Test]
        public void CheckIfWeaponLosesDurabilityAfterEachAttach()
        {
            this.axe.Attack(dummy);

            Assert.That(this.axe.DurabilityPoints, Is.EqualTo(24), "Axe doesn't change durability");
        }


        [Test]
        public void CheckIfAbleToAttackWithBrokenAxe()
        {
            Axe axe = new Axe(10, 1);

            axe.Attack(this.dummy);

            Assert.That(() => axe.Attack(this.dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }

    }
}
