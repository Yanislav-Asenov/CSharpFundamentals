namespace Emergency_Skeleton
{
    using Emergency_Skeleton.Core;
    using Emergency_Skeleton.Core.IO;
    using Emergency_Skeleton.Interfaces.Core;
    using Emergency_Skeleton.Interfaces.Core.IO;

    public class Startup
    {
        public static void Main()
        {
            IInputReader inputReader = new ConsoleReader();
            IOutputWriter outputWriter = new ConsoleWriter();
            IInputOutputManager inputOutputManager = new IOManager(inputReader, outputWriter);

            IManagementSystem emergencyManagementSystem = new EmergencyManagementSystem();

            IEngine engine = new Engine(inputOutputManager, emergencyManagementSystem);
            engine.Run();
        }
    }
}
