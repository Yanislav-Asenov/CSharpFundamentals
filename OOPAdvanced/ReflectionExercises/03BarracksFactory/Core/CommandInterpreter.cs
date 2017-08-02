using System;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IRepository repository;
    private IUnitFactory unitFactory;
    private ICommandFactory commandFactory;

    public CommandInterpreter(IRepository repository, IUnitFactory unitFactory, ICommandFactory commandFactory)
    {
        this.repository = repository;
        this.unitFactory = unitFactory;
        this.commandFactory = commandFactory;
    }

    public IExecutable InterpretCommand(string[] data, string commandName)
    {
        try
        {
            IExecutable command = this.commandFactory.CreateCommand(data);

            FieldInfo[] fieldsToInject = command.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate && f.GetCustomAttributes<InjectAttribute>().Any())
                .ToArray();

            foreach (FieldInfo field in fieldsToInject)
            {
                if (field.FieldType.Name.Contains("Repository"))
                {
                    field.SetValue(command, this.repository);
                }
                else if (field.FieldType.Name.Contains("UnitFactory"))
                {
                    field.SetValue(command, this.unitFactory);
                }
                else
                {
                    throw new InvalidOperationException("Invalid injectable field.");
                }
            }

            return command;
        }
        catch
        {
            throw new InvalidOperationException("Invalid command!");
        }
    }
}