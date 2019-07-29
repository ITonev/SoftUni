using System;
using System.Text;
using System.Collections.Generic;

using CustomTestingFramework.Asserts;
using CustomTestingFramework.Attributes;

namespace CustomTestingFramework.Tests
{
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void ShouldSumSuccessfullyTwoValues()
        {
            int a = 2;
            int b = 3;

            int actualSum = a + b;
            int expectedSum = 5;

            Assert.AreEqual(actualSum, expectedSum);
        }

        [TestMethod]
        public void ShouldDivideSuccessfullyTwoValues()
        {
            int a = 10;
            int b = 5;

            int actualValue = a / b;
            int expectedValue = 2;

            Assert.AreEqual(actualValue, expectedValue);
        }

        [TestMethod]
        public void ShouldMultipySuccessfullyTwoValues()
        {
            int a = 10;
            int b = 5;

            int actualValue = a * b;
            int expectedValue = 20;

            Assert.AreEqual(actualValue, expectedValue);
        }
    }
}
