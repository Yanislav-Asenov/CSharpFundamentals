public class StartUp
{
    public static void Main()
    {
        IWriter writer = new ConsoleWriter();
        IReader reader = new ConsoleReader();
        IInputOutputManager inputOutputManager = new InputOutputManager(writer, reader);

        IManager manager = new HeroManager();

        IRunnable engine = new Engine(inputOutputManager, manager);
        engine.Run();
    }
}