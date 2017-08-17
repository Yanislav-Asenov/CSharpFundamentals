namespace RecyclingStation.Entities.Garbages
{
    using RecyclingStation.BusinessLogic.Attributes;
    using RecyclingStation.BusinessLogic.Strategies;

    [BurnableDisposal(typeof(BurnableGarbageDisposalStrategy))]
    public class BurnableGarbage : Garbage
    {
        public BurnableGarbage(string name, double weight, double volumePerKg)
            : base(name, weight, volumePerKg)
        {
        }
    }
}
