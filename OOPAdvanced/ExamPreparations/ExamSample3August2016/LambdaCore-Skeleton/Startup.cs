namespace LambdaCore_Skeleton
{
    using LambdaCore_Skeleton.Core;
    using LambdaCore_Skeleton.Core.IO;
    using LambdaCore_Skeleton.Interfaces.Core;
    using LambdaCore_Skeleton.Interfaces.Core.IO;

    public class Startup
    {
        public static void Main()
        {
            IInputReader inputReader = new ConsoleReader();
            IOutputWriter outputWriter = new ConsoleWriter();
            IInputOutputManager inputOutputManager = new IOManager(inputReader, outputWriter);

            IRunnable engine = new Engine(inputOutputManager);
        }
    }
}
