namespace LambdaCore_Skeleton.Core
{
    using LambdaCore_Skeleton.Interfaces.Core;
    using LambdaCore_Skeleton.Interfaces.Core.IO;

    public class Engine : IRunnable
    {
        private const string TerminateProgramCommand = "System Shutdown!";

        private readonly IInputOutputManager inputOutputManager;
        private readonly IInterpreter commandInterpreter;

        public Engine(IInputOutputManager inputOutputManager, IInterpreter commandInterpreter)
        {
            this.inputOutputManager = inputOutputManager;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string inputLine = this.inputOutputManager.ReadLine();
            while (inputLine != TerminateProgramCommand)
            {
                string commandResult = this.commandInterpreter.InterpretCommand(inputLine);
                this.inputOutputManager.WriteLine(commandResult);

                inputLine = this.inputOutputManager.ReadLine();
            }
        }
    }
}
