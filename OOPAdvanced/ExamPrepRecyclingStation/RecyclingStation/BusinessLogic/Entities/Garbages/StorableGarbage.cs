namespace RecyclingStation.Entities.Garbages
{
    using RecyclingStation.BusinessLogic.Attributes;
    using RecyclingStation.BusinessLogic.Strategies;

    [StorableDisposal(typeof(StorableGarbageDisposalStrategy))]
    public class StorableGarbage : Garbage
    {
        public StorableGarbage(string name, double weight, double volumePerKg)
            : base(name, weight, volumePerKg)
        {
        }
    }
}
