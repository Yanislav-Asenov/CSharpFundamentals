namespace LambdaCore_Skeleton.Core.Commands
{
    using System.Collections.Generic;
    using LambdaCore_Skeleton.Interfaces.Core;
    using LambdaCore_Skeleton.Attributes;

    [Command("SelectCore")]
    public class SelectCoreCommand : BaseCommand
    {
        private const string SelectCoreCommandSuccessMessage = "Currently selected Core {0}!";
        private const string SelectCoreCommandFailMessage = "Failed to select Core {0}!";

        public SelectCoreCommand(IList<string> args, IPlantController plantController) 
            : base(args, plantController)
        {
        }

        public override string Execute()
        {
            string result = string.Empty;
            string targetCoreId = this.Args[0];

            try
            {
                this.PlantController.SelectCore(targetCoreId);

                result = string.Format(SelectCoreCommandSuccessMessage, targetCoreId);
            }
            catch
            {
                result = string.Format(SelectCoreCommandFailMessage, targetCoreId);
            }

            return result;
        }
    }
}
