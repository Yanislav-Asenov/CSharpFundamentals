using System;

public class CommandFactory : ICommandFactory
{
    public IExecutable CreateCommand(string[] data)
    {
        string commandName = char.ToUpper(data[0][0]).ToString() + data[0].Substring(1) + "Command";
        Type targetUnitType = Type.GetType(commandName);
        IExecutable commandInstance = (IExecutable)Activator.CreateInstance(targetUnitType, new object[] { data });

        return commandInstance;
    }
}