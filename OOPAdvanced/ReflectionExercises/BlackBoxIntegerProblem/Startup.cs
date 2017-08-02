using System;
using System.Reflection;

public class Startup
{
    public static void Main()
    {
        Type blackBoxIntClassType = typeof(BlackBoxInt);

        BlackBoxInt blackBoxIntClassInstance = (BlackBoxInt)Activator.CreateInstance(blackBoxIntClassType, true);

        string command = Console.ReadLine();
        while (command != "END")
        {
            string[] commandArgs = command.Split('_');

            string commandType = commandArgs[0];
            object commandValue = int.Parse(commandArgs[1]);

            MethodInfo targetMethod = blackBoxIntClassType.GetMethod(commandType, BindingFlags.NonPublic | BindingFlags.Instance);
            targetMethod.Invoke(blackBoxIntClassInstance, new object[] { commandValue });

            FieldInfo valueField = blackBoxIntClassType.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(valueField.GetValue(blackBoxIntClassInstance));

            command = Console.ReadLine();
        }
    }
}