using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Startup
{
    public static void Main()
    {
        Type harvestingFieldsClassType = typeof(HarvestingFields);

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "HARVEST")
            {
                Environment.Exit(0);
            }

            string targetFieldsAsString = GetTargetFieldsAsString(harvestingFieldsClassType, command);
            Console.WriteLine(targetFieldsAsString);
        }
    }

    private static string GetTargetFieldsAsString(Type targetClassType, string command)
    {
        FieldInfo[] fields = GetFieldsForClassTypeByAccessModifiers(targetClassType, command);

        string result = GetFieldsAsString(fields);
        return result;
    }

    private static string GetFieldsAsString(FieldInfo[] fields)
    {
        StringBuilder result = new StringBuilder();
        foreach (FieldInfo field in fields)
        {
            result.AppendLine($"{GetAccessModifierByFieldInfo(field)} {field.FieldType.Name} {field.Name}");
        }

        return result.ToString().Trim();
    }

    public static FieldInfo[] GetFieldsForClassTypeByAccessModifiers(Type targetClass, string targetFieldAccessModifiers)
    {
        FieldInfo[] fields = targetClass.GetFields(BindingFlags.Instance 
            | BindingFlags.Public 
            | BindingFlags.NonPublic 
            | BindingFlags.Static 
            | BindingFlags.FlattenHierarchy);

        if (targetFieldAccessModifiers == "private")
        {
            return fields.Where(f => f.IsPrivate).ToArray();
        }
        else if (targetFieldAccessModifiers == "public")
        {
            return fields.Where(f => f.IsPublic).ToArray();
        }
        else if (targetFieldAccessModifiers == "protected")
        {
            return fields.Where(f => f.IsFamily).ToArray();
        }
        else if (targetFieldAccessModifiers == "all")
        {
            return fields;
        }
        else
        {
            return new FieldInfo[0];
        }
    }

    public static string GetAccessModifierByFieldInfo(FieldInfo field)
    {
        if (field.IsPrivate)
        {
            return "private";
        }
        else if (field.IsFamily)
        {
            return "protected";
        }
        else
        {
            return "public";
        }
    }
}