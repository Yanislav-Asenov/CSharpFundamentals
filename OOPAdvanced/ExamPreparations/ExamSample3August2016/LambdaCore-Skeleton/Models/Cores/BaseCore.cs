namespace LambdaCore_Skeleton.Models.Cores
{
    using LambdaCore_Skeleton.Interfaces.Models;

    public abstract class BaseCore : ICore
    {
        private string id;
        private string type;
        private int durability;

        protected BaseCore(string id, string type, int durability)
        {
            this.Id = id;
            this.Type = type;
            this.Durability = durability;
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
