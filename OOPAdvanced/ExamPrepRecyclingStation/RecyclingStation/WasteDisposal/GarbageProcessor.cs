namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Linq;
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class GarbageProcessor : IGarbageProcessor
    {
        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
        }

        public IStrategyHolder StrategyHolder { get; private set; }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            Type type = garbage.GetType();
            DisposableAttribute disposalAttribute = type.GetCustomAttributes(typeof(DisposableAttribute), true).FirstOrDefault() as DisposableAttribute;
            if (disposalAttribute == null)
            {
                throw new ArgumentException("The passed in garbage does not implement a supported Disposable Strategy Attribute.");
            }

            IGarbageDisposalStrategy currentStrategy = Activator.CreateInstance(disposalAttribute.GarbageDisposalStrategyType, new object[0]) as IGarbageDisposalStrategy;

            if (currentStrategy == null)
            {
                throw new ArgumentException("The passed in garbage's Strategy Attribute does not contain supported Disposal Strategy.");
            }

            return currentStrategy.ProcessGarbage(garbage);
        }
    }
}
