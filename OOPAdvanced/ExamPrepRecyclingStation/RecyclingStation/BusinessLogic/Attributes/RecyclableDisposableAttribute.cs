namespace RecyclingStation.BusinessLogic.Attributes
{
    using System;
    using RecyclingStation.WasteDisposal.Attributes;

    public class RecyclableDisposableAttribute : DisposableAttribute
    {
        public RecyclableDisposableAttribute(Type garbageDisposalStrategyType) 
            : base(garbageDisposalStrategyType)
        {
        }
    }
}
