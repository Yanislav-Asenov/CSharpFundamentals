namespace LambdaCore_Skeleton.Core.Commands
{
    using System.Collections.Generic;
    using LambdaCore_Skeleton.Attributes;
    using LambdaCore_Skeleton.Interfaces.Core;
    using LambdaCore_Skeleton.Interfaces.Models;

    [Command("DetachFragment")]
    public class DetachFragmentCommand : BaseCommand
    {
        private const string DetachFragmentCommandSuccessMessage = "Successfully detached Fragment {0} from Core {1}!";
        private const string DetachFragmentCommandFailMessage = "Failed to detach Fragment!";

        public DetachFragmentCommand(IList<string> args, IPlantController plantController) 
            : base(args, plantController)
        {
        }

        public override string Execute()
        {
            string result = string.Empty;

            try
            {
                IFragment detachedFragment = this.PlantController.DetachFragment();

                result = string.Format(DetachFragmentCommandSuccessMessage, detachedFragment.Name, this.PlantController.SelectedCore.Id);
            }
            catch
            {
                result = DetachFragmentCommandFailMessage;
            }

            return result;
        }
    }
}
