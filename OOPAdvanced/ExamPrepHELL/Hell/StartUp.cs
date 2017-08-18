public class StartUp
{
    public static void Main()
    {
        IInputReader writer = new OutputWriter();
        IOutputWriter reader = new InputReader();

        IManager manager = new HeroManager();

        IRunnable engine = new Engine(reader, writer, manager);
        engine.Run();
    }
}