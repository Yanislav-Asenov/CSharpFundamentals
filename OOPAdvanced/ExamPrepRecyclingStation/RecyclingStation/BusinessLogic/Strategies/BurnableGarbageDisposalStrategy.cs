namespace RecyclingStation.BusinessLogic.Strategies
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public class BurnableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double GetCapitalBalance(IWaste garbage)
        {
            double capitalEarned = 0;
            double capitalUsed = 0;

            return capitalEarned - capitalUsed;
        }

        protected override double GetEnergyBalance(IWaste garbage)
        {
            double energyProduced = garbage.GetTotalVolume();
            double energyUsed = garbage.GetTotalVolume() * 0.2;

            return energyProduced - energyUsed;
        }
    }
}
