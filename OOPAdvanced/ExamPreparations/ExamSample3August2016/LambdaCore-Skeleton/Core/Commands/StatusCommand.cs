namespace LambdaCore_Skeleton.Core.Commands
{
    using System.Collections.Generic;
    using LambdaCore_Skeleton.Attributes;
    using LambdaCore_Skeleton.Interfaces.Core;

    [Command("Status")]
    public class StatusCommand : BaseCommand
    {
        public StatusCommand(IList<string> args, IPlantController plantController) 
            : base(args, plantController)
        {
        }

        public override string Execute()
        {
            string result = this.PlantController.GetStatus();
            return result;
        }
    }
}
