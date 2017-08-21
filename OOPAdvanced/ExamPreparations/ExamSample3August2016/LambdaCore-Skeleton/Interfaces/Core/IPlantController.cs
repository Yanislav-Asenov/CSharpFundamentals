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
    }
}
