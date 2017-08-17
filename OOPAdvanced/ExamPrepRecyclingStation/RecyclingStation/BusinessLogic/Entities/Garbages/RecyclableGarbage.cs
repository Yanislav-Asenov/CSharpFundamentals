namespace RecyclingStation.Entities.Garbages
{
    using RecyclingStation.BusinessLogic.Attributes;
    using RecyclingStation.BusinessLogic.Strategies;

    [RecyclableDisposable(typeof(RecyclableGarbageDisposalStrategy))]
    public class RecyclableGarbage : Garbage
    {
        public RecyclableGarbage(string name, double weight, double volumePerKg)
            : base(name, weight, volumePerKg)
        {
        }
    }
}
