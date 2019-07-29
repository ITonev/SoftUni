using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

using CustomTestingFramework.Contracts;
using CustomTestingFramework.Attributes;
using CustomTestingFramework.Exceptions;

namespace CustomTestingFramework.TestRunner
{
    public class TestRunner : ITestRunner
    {
        private readonly ICollection<string> resultInfo;

        public TestRunner()
        {
            this.resultInfo = new List<string>();
        }

        public ICollection<string> Run(string path)
        {
            var testClasses = Assembly
                .LoadFrom(path)
                .GetTypes()
                .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(TestClassAttribute)))
                .ToList();

            foreach (var testClass in testClasses)
            {
                var testMethods = testClass
                    .GetMethods()
                    .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(TestMethodAttribute)))
                   .ToList();

                var classInstance = Activator.CreateInstance(testClass); 

                foreach (var method in testMethods)
                {
                    try
                    {
                        method.Invoke(classInstance, null);

                        this.resultInfo.Add($"Method: {method.Name} passed");
                    }
                    catch (TargetInvocationException e)
                    {
                        this.resultInfo.Add($"Method: {method.Name} failed with message - {e.InnerException.Message}");
                    }
                }
            }

            return this.resultInfo;
        }
    }
}
