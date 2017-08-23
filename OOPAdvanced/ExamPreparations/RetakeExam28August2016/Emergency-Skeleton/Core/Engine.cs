namespace Emergency_Skeleton.Core
{
    using Emergency_Skeleton.Interfaces.Core;
    using Emergency_Skeleton.Interfaces.Core.IO;

    public class Engine : IEngine
    {
        private const string TerminateProgramCommand = "EmergencyBreak";

        private readonly IInputOutputManager inputOutputManager;
        private readonly IManagementSystem managementSystem;

        public Engine(IInputOutputManager inputOutputManager, IManagementSystem managementSystem)
        {
            this.inputOutputManager = inputOutputManager;
            this.managementSystem = managementSystem;
        }

        public void Run()
        {
            string inputLine = this.inputOutputManager.ReadLine();
            while (inputLine != TerminateProgramCommand)
            {
                this.inputOutputManager.WriteLine("Output: " + inputLine);
                inputLine = this.inputOutputManager.ReadLine();
            }
        }
    }
}
