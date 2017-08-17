using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.BusinessLogic.Strategies
{
    public class RecyclableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double GetCapitalBalance(IWaste garbage)
        {
            double capitalEarned = 400 * garbage.Weight;
            double capitalUsed = 0;

            return capitalEarned - capitalUsed;
        }

        protected override double GetEnergyBalance(IWaste garbage)
        {
            double energyProduced = 0;
            double energyUsed = garbage.GetTotalVolume() * 0.5;

            return energyProduced - energyUsed;
        }
    }
}
