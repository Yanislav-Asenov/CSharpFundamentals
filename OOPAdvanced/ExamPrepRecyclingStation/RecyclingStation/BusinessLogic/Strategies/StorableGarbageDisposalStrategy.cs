namespace RecyclingStation.BusinessLogic.Strategies
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public class StorableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double GetCapitalBalance(IWaste garbage)
        {
            double capitalEarned = 0;
            double capitalUsed = garbage.GetTotalVolume() * 0.65;

            return capitalEarned - capitalUsed;
        }

        protected override double GetEnergyBalance(IWaste garbage)
        {
            double energyProduced = 0;
            double energyUsed = garbage.GetTotalVolume() * 0.13;

            return energyProduced - energyUsed;
        }
    }
}
