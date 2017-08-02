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
}