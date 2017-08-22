namespace LambdaCore_Skeleton.Models.Cores
{
    using LambdaCore_Skeleton.Collections;
    using LambdaCore_Skeleton.Enums;
    using LambdaCore_Skeleton.Interfaces.Collections;
    using LambdaCore_Skeleton.Interfaces.Models;
    using System;
    using System.Text;

    public abstract class BaseCore : ICore
    {
        private string id;
        private string type;
        private int durability;
        private ILStack<IFragment> fragments;

        protected BaseCore(string id, string type, int durability)
        {
            this.Id = id;
            this.Type = type;
            this.Durability = durability;
            this.fragments = new LStack<IFragment>();
        }

        public string Id
        {
            get => this.id;
            private set => this.id = value;
        }

        public string Type
        {
            get => this.type;
            set => this.type = value;
        }

        public virtual int Durability
        {
            get
            {
                // THE CORE'S DURABILITY - THE CURRENT PRESSURE ON THE CORE
                // IF THE PRESSURE IS BELOW ZERO OR ZERO THE CORE'S DURABILITY WILL REMAIN AT MAXIMUM
                // BECAUSE THE .getCurrentPressure() METHOD WILL NOT RETURN A VALUE BELOW ZERO
                int result = (int)(this.durability - this.CurrentPressure);

                // THE DURABILITY SHOULD NOT FALL BELOW ZERO
                return result > 0 ? result : 0;
            }

            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.durability = value;
            }
        }

        public CoreState State
        {
            get => this.CurrentPressure > 0 ? CoreState.CRITICAL : CoreState.NORMAL;
        }

        public long CurrentPressure
        {
            get
            {
                long totalPressure = 0;

                foreach (IFragment fragment in this.fragments)
                {
                    if (fragment.Type.Equals(FragmentType.Nuclear))
                    {
                        totalPressure += fragment.PressureAffection;
                    }
                    else
                    {
                        totalPressure -= fragment.PressureAffection;
                    }
                }

                return totalPressure > 0 ? totalPressure : 0;
            }
        }

        public int TotalNumberOfFragments => this.fragments.Count();

        public void AttachFragment(IFragment fragment)
        {
            this.fragments.Push(fragment);
        }

        public IFragment DetachFragment()
        {
            if (this.fragments.IsEmpty())
            {
                throw new InvalidOperationException("Fragments collection is empty!");
            }
        
            IFragment fragment = this.fragments.Peek();
            this.fragments.Pop();

            return fragment;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Core {this.Id}:");
            result.AppendLine($"####Durability: {this.Durability}");
            result.AppendLine($"####Status: {this.State.ToString()}");

            return result.ToString().Trim();
        }
    }
}
