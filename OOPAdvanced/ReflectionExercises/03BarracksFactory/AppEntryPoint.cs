public class AppEntryPoint
{
    static void Main()
    {
        IRepository repository = new Repository();
        IUnitFactory unitFactory = new UnitFactory();
        ICommandFactory commandFactory = new CommandFactory();
        ICommandInterpreter commandInterpreter = new CommandInterpreter(repository, unitFactory, commandFactory);
        IRunnable engine = new Engine(commandInterpreter);
        engine.Run();
    }
}