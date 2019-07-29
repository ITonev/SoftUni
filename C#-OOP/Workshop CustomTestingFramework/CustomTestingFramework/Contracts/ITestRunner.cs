using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTestingFramework.Contracts
{
    public interface ITestRunner
    {
        ICollection<string> Run(string path);
    }
}
