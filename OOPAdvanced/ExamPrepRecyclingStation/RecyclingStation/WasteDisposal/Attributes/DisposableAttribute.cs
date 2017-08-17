namespace RecyclingStation.WasteDisposal.Attributes
{
    using System;

    /// <summary>
    /// An attribute class, that represents the base of all Disposable Attribute classes.
    /// </summary>

    [AttributeUsage(AttributeTargets.Class)]
    public class DisposableAttribute : Attribute
    {
        private readonly Type garbageDisposalStrategyType;

        public DisposableAttribute(Type garbageDisposalStrategyType)
        {
            this.garbageDisposalStrategyType = garbageDisposalStrategyType;
        }

        public Type GarbageDisposalStrategyType
        {
            get => this.garbageDisposalStrategyType;
        }
    }
}
