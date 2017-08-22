namespace LambdaCore_Skeleton.Interfaces.Factories
{
    using LambdaCore_Skeleton.Interfaces.Models;

    public interface IFragmentFactory
    {
        IFragment CreateFragment(string type, string name, int pressureAffection);
    }
}
