namespace RecyclingStation.BusinessLogic.Attributes
{
    using System;
    using RecyclingStation.WasteDisposal.Attributes;

    public class BurnableDisposalAttribute : DisposableAttribute
    {
        public BurnableDisposalAttribute(Type garbageDisposalStrategyType) 
            : base(garbageDisposalStrategyType)
        {
        }
    }
}
