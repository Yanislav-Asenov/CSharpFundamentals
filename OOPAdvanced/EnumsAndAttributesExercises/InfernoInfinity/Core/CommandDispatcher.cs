using System;
using System.Collections.Generic;
using System.Linq;

public class CommandDispatcher : ICommandDispatcher
{
    private IDictionary<string, ICommand> commands;

    public CommandDispatcher()
    {
        this.InitializeCommands();
    }

    public void DispatchCommand(
        string[] commandParameters, 
        IDictionary<string, IWeapon> weapons, 
        IWeaponFactory weaponFactory, 
        IInputOutputManager inputOutputManager,
        IGemFactory gemFactory)
    {
        string commandName = commandParameters[0];
        string[] parameters = commandParameters.Skip(1).ToArray();

        if (!this.commands.ContainsKey(commandName))
        {
            throw new InvalidOperationException($"Command {commandName} not valid!");
        }

        this.commands[commandName].Execute(parameters, weapons, weaponFactory, inputOutputManager, gemFactory);
    }

    private void InitializeCommands()
    {
        this.commands = new Dictionary<string, ICommand>()
        {
            ["Create"] = new CreateWeaponCommand(),
            ["Add"] = new AddGemCommand(),
            ["Remove"] = new RemoveGemCommand(),
            ["Print"] = new PrintWeaponCommand(),
            ["END"] = new EndCommand(),
        };
    }
}