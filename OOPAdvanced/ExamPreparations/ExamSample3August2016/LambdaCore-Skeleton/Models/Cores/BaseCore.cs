namespace LambdaCore_Skeleton.Models.Cores
{
    using LambdaCore_Skeleton.Interfaces.Models;

    public abstract class BaseCore : ICore
    {
        private string type;
        private int durability;

        protected BaseCore(string type, int durability)
        {
            this.Type = type;
            this.Durability = durability;
        }

        public string Type
        {
            get => this.type;
            set => this.type = value;
        }

        public virtual int Durability
        {
            get => this.durability;
            set
            {
                this.durability = value;

                if (this.durability < 0)
                {
                    this.durability = 0;
                }
            }
        }
    }
}
