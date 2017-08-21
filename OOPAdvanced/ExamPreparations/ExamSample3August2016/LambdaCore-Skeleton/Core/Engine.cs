namespace LambdaCore_Skeleton.Core
{
    using LambdaCore_Skeleton.Interfaces.Core;
    using LambdaCore_Skeleton.Interfaces.Core.IO;

    public class Engine : IRunnable
    {
        private readonly IInputOutputManager inputOutputManager;

        public Engine(IInputOutputManager inputOutputManager)
        {
            this.inputOutputManager = inputOutputManager;
        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }
    }
}
