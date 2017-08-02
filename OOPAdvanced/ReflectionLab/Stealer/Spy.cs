using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string targetClassName, params string[] targetFieldNames)
    {
        Type targetClassType = Type.GetType(targetClassName);
        FieldInfo[] targetClassFields =
            targetClassType
                .GetFields(BindingFlags.Instance
                | BindingFlags.Static
                | BindingFlags.NonPublic
                | BindingFlags.Public);

        Object targetClassInstance = Activator.CreateInstance(targetClassType, new object[] { });

        StringBuilder result = new StringBuilder();
        result.Append($"Class under investigation: {targetClassName}")
            .AppendLine();

        foreach (FieldInfo field in targetClassFields.Where(f => targetFieldNames.Contains(f.Name)))
        {
            result.Append($"{field.Name} = {field.GetValue(targetClassInstance)}")
                .AppendLine();
        }

        return result.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string targetClassName)
    {
        Type targetClassType = Type.GetType(targetClassName);
        FieldInfo[] targetClassPublicFields = targetClassType
            .GetFields(BindingFlags.Public 
            | BindingFlags.Instance
            | BindingFlags.Static);

        MethodInfo[] targetClassPublicMethods = targetClassType
            .GetMethods(BindingFlags.Public | BindingFlags.Instance);

        MethodInfo[] targetClassNonPublicMethods = targetClassType
            .GetMethods(BindingFlags.NonPublic| BindingFlags.Instance);

        StringBuilder result = new StringBuilder();
        foreach (FieldInfo field in targetClassPublicFields)
        {
            result.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo method in targetClassNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            result.AppendLine($"{method.Name} have to be public!");
        }

        foreach (MethodInfo method in targetClassPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            result.AppendLine($"{method.Name} have to be private!");
        }

        return result.ToString().Trim();
    }

    public string RevealPrivateMethods(string targetClassName)
    {
        Type targetClassType = Type.GetType(targetClassName);
        
        StringBuilder result = new StringBuilder();
        result.AppendLine($"All Private Methods of Class: {targetClassName}");
        result.AppendLine($"Base Class: {targetClassType.BaseType.Name}");

        MethodInfo[] targetClassPrivateMethods = targetClassType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (MethodInfo method in targetClassPrivateMethods)
        {
            result.AppendLine(method.Name);
        }
    
        return result.ToString().Trim();
    }

    public string CollectGettersAndSetters(string targetClassName)
    {
        Type targetClassType = Type.GetType(targetClassName);
        MethodInfo[] targetClassMethods = targetClassType.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

        StringBuilder result = new StringBuilder();
        MethodInfo[] targetClassGetters = targetClassMethods.Where(m => m.Name.StartsWith("get")).ToArray();
        foreach (MethodInfo method in targetClassGetters)
        {
            result.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        MethodInfo[] targetClassSetters = targetClassMethods.Where(m => m.Name.StartsWith("set")).ToArray();
        foreach (MethodInfo method in targetClassSetters)
        {
            result.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return result.ToString().Trim();
    }
}