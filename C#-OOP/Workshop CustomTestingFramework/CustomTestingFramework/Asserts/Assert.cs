using System;
using System.Text;
using System.Collections.Generic;
using CustomTestingFramework.Exceptions;

namespace CustomTestingFramework.Asserts
{
    public class Assert
    {
        public static bool AreEqual(int a, int b)
        {
            if (a != b)
            {
                throw new TestException("Not equal");
            }

            return true;
        }
    }

}
