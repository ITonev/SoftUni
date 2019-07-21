using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var classType = typeof(StartUp);

        var methods = classType.GetMethods(BindingFlags.Instance
                            | BindingFlags.Public
                            | BindingFlags.Static);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(x=>x.AttributeType==typeof(AuthorAttribute)))
            {
                var methodAtts = method.GetCustomAttributes(false);

                foreach (AuthorAttribute att in methodAtts)
                {
                    Console.WriteLine($"{method.Name} is written by {att.Name}");
                }
            }
        }
    }
}

