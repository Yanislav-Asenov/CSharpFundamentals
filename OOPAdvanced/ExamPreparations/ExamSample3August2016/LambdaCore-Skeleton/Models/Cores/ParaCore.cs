namespace LambdaCore_Skeleton.Models.Cores
{
    public class ParaCore : BaseCore
    {
        private const int ParaCoreDurabilityDivider = 3;

        public ParaCore(string id, string type, int durability) 
            : base(id, type, durability)
        {
        }

        public override int Durability
        {
            get => base.Durability / ParaCoreDurabilityDivider;
            set => base.Durability = value;
        }
    }
}
