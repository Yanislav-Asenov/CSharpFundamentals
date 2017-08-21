namespace LambdaCore_Skeleton.Interfaces.Models
{
    using LambdaCore_Skeleton.Enums;

    public interface IFragment
    {
        string Name { get; }

        FragmentType Type { get; }

        int PressureAffection { get; }
    }
}
