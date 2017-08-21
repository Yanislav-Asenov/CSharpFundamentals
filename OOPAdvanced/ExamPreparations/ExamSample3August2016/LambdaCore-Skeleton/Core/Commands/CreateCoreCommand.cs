namespace LambdaCore_Skeleton.Core.Commands
{
    using LambdaCore_Skeleton.Attributes;
    using LambdaCore_Skeleton.Interfaces.Core;
    using LambdaCore_Skeleton.Interfaces.Models;
    using System.Collections.Generic;

    [Command("CreateCore")]
    public class CreateCoreCommand : BaseCommand
    {
        private const string CreateCoreCommandSuccessMessage = "Successfully created Core {0}!";
        private const string CreateCoreCommandFailMessage = "Failed to create Core!";

        public CreateCoreCommand(IList<string> args, IPlantController plantController) 
            : base(args, plantController)
        {
        }

        public override string Execute()
        {
            string result = string.Empty;

            try
            {
                string coreType = this.Args[0];
                int coreDurability = int.Parse(this.Args[1]);
                ICore createdCore = this.PlantController.CreateCore(coreType, coreDurability);

                result = string.Format(CreateCoreCommandSuccessMessage, createdCore.Id);
            }
            catch
            {
                result = CreateCoreCommandFailMessage;
            }

            return result;
        }
    }
}
