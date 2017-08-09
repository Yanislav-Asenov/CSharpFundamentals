namespace BashSoft.IO
{
    using System;
    using System.Linq;
    using System.Reflection;
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.IO.Commands;

    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase studentsRepository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.studentsRepository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpretCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];

            try
            {
                IExecutable command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }
        }

        private IExecutable ParseCommand(string input, string commandName, string[] data)
        {
            Type typeOfCommand =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .First(type => type.GetCustomAttributes(typeof(AliasAttribute))
                            .Where(atr => atr.Equals(commandName))
                            .ToArray().Length > 0);

            Type typeOfCommandInterpreter = typeof(CommandInterpreter);

            object[] parametersForConstructor = new object[]
            {
                input,
                data,
            };
            Command command = (Command)Activator.CreateInstance(typeOfCommand, parametersForConstructor);

            FieldInfo[] fieldsOfCommand = typeOfCommand
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            FieldInfo[] fieldsOfInterpreter = typeOfCommandInterpreter
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo fieldOfCommand in fieldsOfCommand)
            {
                Attribute injectAttribute = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));

                if (injectAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(f => f.FieldType == fieldOfCommand.FieldType))
                    {
                        fieldOfCommand.SetValue(command,
                            fieldsOfInterpreter.First(f => f.FieldType == fieldOfCommand.FieldType)
                            .GetValue(this));
                    }
                }
            }

            return command;
        }
    }
}
