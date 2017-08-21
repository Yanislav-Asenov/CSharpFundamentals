namespace LambdaCore_Skeleton.Models.Fragments
{
    using LambdaCore_Skeleton.Enums;
    using LambdaCore_Skeleton.Interfaces.Models;

    public abstract class BaseFragment : IFragment
    {
        private string name;
        private int pressureAffection;

        protected BaseFragment(string name, int pressureAffection)
        {
            this.Name = name;
            this.PressureAffection = pressureAffection;
        }

        public string Name
        {
            get => this.name;
            protected set => this.name = value;
        }

        public abstract FragmentType Type { get; }

        public virtual int PressureAffection
        {
            get => this.pressureAffection;
            protected set => this.pressureAffection = value;
        }
    }
}
