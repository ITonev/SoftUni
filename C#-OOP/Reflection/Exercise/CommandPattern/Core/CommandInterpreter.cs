using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var tokens = args
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var command = tokens[0]+"Command";

            var arguments = tokens.Skip(1).ToArray();

            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name==command);

            var activatedInstance = Activator.CreateInstance(type);
           
            var method = type
                .GetMethod("Execute", BindingFlags.Public | BindingFlags.Instance);

            var methodInvoke = method
                .Invoke(activatedInstance, new object[] { arguments });

            return methodInvoke.ToString();
        }
    }
}
