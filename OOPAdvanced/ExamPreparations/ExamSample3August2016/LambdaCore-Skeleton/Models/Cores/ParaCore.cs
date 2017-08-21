namespace LambdaCore_Skeleton.Models.Cores
{
    public class ParaCore : BaseCore
    {
        private const int ParaCoreDurabilityDivider = 3;

        public ParaCore(string type, int durability) 
            : base(type, durability)
        {
        }

        public override int Durability
        {
            get => base.Durability / ParaCoreDurabilityDivider;
            set => base.Durability = value;
        }
    }
}
