using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(Startup);
        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        foreach (var methodInfo in methods)
        {
            if (methodInfo.CustomAttributes.Any(a => a.AttributeType == typeof(SoftUniAttribute)))
            {
                var attributes = methodInfo.GetCustomAttributes(false);
                StringBuilder result = new StringBuilder();
                foreach (SoftUniAttribute attribute in attributes)
                {
                    result.Append($"{methodInfo.Name} is written by {attribute.Name}{Environment.NewLine}");
                }

                Console.Write(result);
            }
        }
    }
}