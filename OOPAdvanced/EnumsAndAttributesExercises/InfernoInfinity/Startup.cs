public class Startup
{
    public static void Main()
    {
        IInputOutputManager inputOutputManager = new InputOutputManager();
        ICommandDispatcher commandDispatcher = new CommandDispatcher();
        IWeaponFactory weaponFactory = new WeaponFactory();
        IGemFactory gemFactory = new GemFactory();

        IEngine engine = new Engine(inputOutputManager, commandDispatcher, weaponFactory, gemFactory);
        engine.Run();
    }
}