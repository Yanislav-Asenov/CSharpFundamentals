namespace LambdaCore_Skeleton.Core.Commands
{
    using System.Collections.Generic;
    using LambdaCore_Skeleton.Attributes;
    using LambdaCore_Skeleton.Interfaces.Core;

    [Command("RemoveCore")]
    public class RemoveCoreCommand : BaseCommand
    {
        private const string RemoveCoreCommandSuccessMessage = "Successfully removed Core {0}!";
        private const string RemoveCoreCommandFailMessage = "Failed to remove Core {0}!";

        public RemoveCoreCommand(IList<string> args, IPlantController plantController) 
            : base(args, plantController)
        {
        }

        public override string Execute()
        {
            string result = string.Empty;
            string targetCoreId = this.Args[0];

            try
            {
                this.PlantController.RemoveCore(targetCoreId);
                result = string.Format(RemoveCoreCommandSuccessMessage, targetCoreId);
            }
            catch
            {
                result = string.Format(RemoveCoreCommandFailMessage, targetCoreId);
            }

            return result;
        }
    }
}
