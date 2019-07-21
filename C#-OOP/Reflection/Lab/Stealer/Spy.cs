using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        var classType = Type.GetType(className);

        var fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public);
        var publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public).Where(x => x.Name.StartsWith("set"));
        var privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.Name.StartsWith("get"));

        StringBuilder sb = new StringBuilder();

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in privateMethods)
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in publicMethods)
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigatedClass);

        var fields = classType.GetFields(BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.NonPublic |
            BindingFlags.Public);


        var classInstance = Activator.CreateInstance(classType, new object[] { });

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {classType}");

        foreach (var field in fields.Where(x => requestedFields.Contains(x.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        var classtype = Type.GetType(className);

        var methods = classtype.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {classtype}")
            .AppendLine($"Base Class: {classtype.BaseType.Name}");

        foreach (var method in methods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        var classType = Type.GetType(className);

        var methods = classType.GetMethods(BindingFlags.Instance
                        | BindingFlags.Public
                        | BindingFlags.Static
                        | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (var method in methods.Where(x=>x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in methods.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().FirstOrDefault().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}

