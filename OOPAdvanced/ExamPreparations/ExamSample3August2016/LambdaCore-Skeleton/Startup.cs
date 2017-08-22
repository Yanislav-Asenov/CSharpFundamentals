namespace LambdaCore_Skeleton
{
    using LambdaCore_Skeleton.Core;
    using LambdaCore_Skeleton.Core.IO;
    using LambdaCore_Skeleton.Factories;
    using LambdaCore_Skeleton.Interfaces.Core;
    using LambdaCore_Skeleton.Interfaces.Core.IO;
    using LambdaCore_Skeleton.Interfaces.Factories;

    public class Startup
    {
        public static void Main()
        {
            IInputReader inputReader = new ConsoleReader();
            IOutputWriter outputWriter = new ConsoleWriter();
            IInputOutputManager inputOutputManager = new IOManager(inputReader, outputWriter);

            ICoreIdManager coreIdManager = new CoreIdManager();
            ICoreFactory coreFactory = new CoreFactory();
            IFragmentFactory fragmentFactory = new FragmentFactory();
            IPlantController plantController = new PlantController(coreIdManager, coreFactory, fragmentFactory);
            IInterpreter commandIntepreter = new CommandInterpreter(plantController);

            IRunnable engine = new Engine(inputOutputManager, commandIntepreter);
            engine.Run();
        }
    }
}
