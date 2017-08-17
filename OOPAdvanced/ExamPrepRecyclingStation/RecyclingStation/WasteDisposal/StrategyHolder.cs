namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Collections.Generic;
    using RecyclingStation.WasteDisposal.Interfaces;

    internal class StrategyHolder : IStrategyHolder
    {
        private readonly IDictionary<Type, IGarbageDisposalStrategy> strategiesByType;

        public StrategyHolder(IDictionary<Type, IGarbageDisposalStrategy> strategiesByType)
        {
            this.strategiesByType = strategiesByType;
        }

        public IReadOnlyDictionary<Type,IGarbageDisposalStrategy> GetDisposalStrategies
        {
            get { return (IReadOnlyDictionary<Type, IGarbageDisposalStrategy>)this.strategiesByType; }
        }

        public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
        {
            if (this.strategiesByType.ContainsKey(disposableAttribute))
            {
                return false;
            }

            this.strategiesByType.Add(disposableAttribute, strategy);
            return true;
        }

        public bool RemoveStrategy(Type disposableAttribute)
        {
            if (!this.strategiesByType.ContainsKey(disposableAttribute))
            {
                return false;
            }

            this.strategiesByType.Remove(disposableAttribute);
            return true;
        }
    }
}
