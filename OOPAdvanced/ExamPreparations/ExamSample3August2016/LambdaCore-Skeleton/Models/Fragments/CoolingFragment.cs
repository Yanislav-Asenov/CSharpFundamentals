namespace LambdaCore_Skeleton.Models.Fragments
{
    using LambdaCore_Skeleton.Enums;

    public class CoolingFragment : BaseFragment
    {
        private const int CoolingFragmentPressureAffectionMultiplier = 3;

        public CoolingFragment(string name, int pressureAffection)
            : base(name, pressureAffection)
        {
        }

        public override int PressureAffection
        {
            get => base.PressureAffection * CoolingFragmentPressureAffectionMultiplier;
            protected set => base.PressureAffection = value;
        }

        public override FragmentType Type => FragmentType.Cooling;
    }
}
