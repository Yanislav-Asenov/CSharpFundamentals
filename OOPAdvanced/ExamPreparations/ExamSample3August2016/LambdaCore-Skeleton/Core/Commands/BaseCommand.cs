namespace LambdaCore_Skeleton.Core.Commands
{
    using LambdaCore_Skeleton.Interfaces.Core.Commands;
    using LambdaCore_Skeleton.Interfaces.Core;
    using System.Collections.Generic;

    public abstract class BaseCommand : ICommand
    {
        private IList<string> args;
        private IPlantController plantController;

        protected BaseCommand(IList<string> args, IPlantController plantController)
        {
            this.Args = args;
            this.PlantController = plantController;
        }

        public IList<string> Args
        {
            get => this.args;
            set => this.args = value;
        }

        public IPlantController PlantController
        {
            get => this.plantController;
            private set => this.plantController = value;
        }
    
        public abstract string Execute();
    }
}
