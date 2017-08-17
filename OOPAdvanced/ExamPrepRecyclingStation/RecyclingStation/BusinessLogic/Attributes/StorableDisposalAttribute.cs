namespace RecyclingStation.BusinessLogic.Attributes
{
    using System;
    using RecyclingStation.WasteDisposal.Attributes;

    public class StorableDisposalAttribute : DisposableAttribute
    {
        public StorableDisposalAttribute(Type garbageDisposalStrategyType) 
            : base(garbageDisposalStrategyType)
        {
        }
    }
}
