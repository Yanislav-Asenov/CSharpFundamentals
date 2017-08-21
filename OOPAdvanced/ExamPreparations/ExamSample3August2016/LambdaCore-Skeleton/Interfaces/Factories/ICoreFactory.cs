namespace LambdaCore_Skeleton.Interfaces.Factories
{
    using LambdaCore_Skeleton.Interfaces.Models;

    public interface ICoreFactory
    {
        ICore CreateCore(string id, string type, int durability);
    }
}
