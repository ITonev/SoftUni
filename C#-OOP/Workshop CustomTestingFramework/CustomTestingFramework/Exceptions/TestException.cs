using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTestingFramework.Exceptions
{
    public class TestException : Exception
    {
        public TestException(string message) 
            : base(message)
        {
        }
    }
}
