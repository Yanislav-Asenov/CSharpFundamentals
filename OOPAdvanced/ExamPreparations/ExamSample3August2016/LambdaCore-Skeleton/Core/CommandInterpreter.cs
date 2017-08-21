namespace LambdaCore_Skeleton.Core
{
    using LambdaCore_Skeleton.Attributes;
    using LambdaCore_Skeleton.Interfaces.Core.Commands;
    using LambdaCore_Skeleton.Interfaces.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : IInterpreter
    {
        private readonly IPlantController plantController;

        public CommandInterpreter(IPlantController plantController)
        {
            this.plantController = plantController;
        }

        public string InterpretCommand(string input)
        {
            string[] data = input.Split(new[] { ':', '@' }, StringSplitOptions.RemoveEmptyEntries);
            string commandName = data[0];
            IList<string> commandArgs = data.Skip(1).ToList();

            ICommand command = this.ParseCommand(commandName, commandArgs);

            return command.Execute();
        }

        private ICommand ParseCommand(string commandName, IList<string> commandArgs)
        {
            Type targetCommandType =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(t => t.GetCustomAttributes<CommandAttribute>().Any(a => a.Name == commandName));

            ICommand targetCommandInstance = Activator.CreateInstance(targetCommandType, commandArgs, this.plantController) as ICommand;

            return targetCommandInstance;
        }
    }
}
