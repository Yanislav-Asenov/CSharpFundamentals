namespace LambdaCore_Skeleton.Interfaces.Core
{
    using LambdaCore_Skeleton.Interfaces.Models;
    using System.Collections.Generic;

    public interface IPlantController
    {
        IDictionary<string, ICore> Cores { get; }

        ICore SelectedCore { get; }

        ICore CreateCore(string type, int durability);

        void RemoveCore(string id);

        void SelectCore(string id);

        IFragment CreateFragment(string type, string name, int pressureAffection);

        void AttachFragment(IFragment fragment);

        IFragment DetachFragment();

        string GetStatus();
    }
}
