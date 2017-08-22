namespace LambdaCore_Skeleton.Core.Commands
{
    using System.Collections.Generic;
    using LambdaCore_Skeleton.Attributes;
    using LambdaCore_Skeleton.Interfaces.Core;
    using LambdaCore_Skeleton.Interfaces.Models;

    [Command("AttachFragment")]
    public class AttachFragmentCommand : BaseCommand
    {
        private const string AttachFragmentCommandSuccessMessage = "Successfully attached Fragment {0} to Core {1}!";
        private const string AttachFragmentCommandFailMessage = "Failed to attach Fragment {0}!";

        public AttachFragmentCommand(IList<string> args, IPlantController plantController) 
            : base(args, plantController)
        {

        }

        public override string Execute()
        {
            string result = string.Empty;
            string fragmentType = this.Args[0];
            string fragmentName = this.Args[1];
            int pressureAffection = int.Parse(this.Args[2]);

            try
            {
                IFragment fragment = this.PlantController.CreateFragment(fragmentType, fragmentName, pressureAffection);
                this.PlantController.AttachFragment(fragment);

                result = string.Format(AttachFragmentCommandSuccessMessage, fragmentName, this.PlantController.SelectedCore.Id);
            }
            catch
            {
                result = string.Format(AttachFragmentCommandFailMessage, fragmentName);
            }

            return result;
        }
    }
}
