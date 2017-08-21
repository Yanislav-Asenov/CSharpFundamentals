namespace LambdaCore_Skeleton.Models.Fragments
{
    using LambdaCore_Skeleton.Enums;

    public class NuclearFragment : BaseFragment
    {
        private const int NuclearFragmentPressureAffectionMultiplier = 2;

        public NuclearFragment(string name, int pressureAffection)
            : base(name, pressureAffection)
        {
        }

        public override int PressureAffection
        {
            get => base.PressureAffection * NuclearFragmentPressureAffectionMultiplier;
            protected set => base.PressureAffection = value;
        }

        public override FragmentType Type => FragmentType.Nuclear;
    }
}
