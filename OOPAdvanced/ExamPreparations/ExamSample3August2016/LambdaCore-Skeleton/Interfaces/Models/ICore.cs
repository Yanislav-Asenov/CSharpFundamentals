namespace LambdaCore_Skeleton.Interfaces.Models
{
    using LambdaCore_Skeleton.Enums;

    public interface ICore
    {
        string Id { get; }

        string Type { get; }

        int Durability { get; }

        CoreState State { get; }

        int TotalNumberOfFragments { get; }

        void AttachFragment(IFragment fragment);

        IFragment DetachFragment();
    }
}
