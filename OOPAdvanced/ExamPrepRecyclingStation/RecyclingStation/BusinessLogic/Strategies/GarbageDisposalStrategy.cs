namespace RecyclingStation.BusinessLogic.Strategies
{
    using RecyclingStation.BusinessLogic.Data;
    using RecyclingStation.WasteDisposal.Interfaces;

    public abstract class GarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            double energyBalance = this.GetEnergyBalance(garbage);
            double capitalBalance = this.GetCapitalBalance(garbage);

            return new ProcessingData(energyBalance, capitalBalance);
        }

        protected abstract double GetEnergyBalance(IWaste garbage);

        protected abstract double GetCapitalBalance(IWaste garbage);
    }
}
