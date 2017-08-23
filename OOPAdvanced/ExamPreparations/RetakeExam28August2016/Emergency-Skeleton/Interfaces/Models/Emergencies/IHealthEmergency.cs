namespace Emergency_Skeleton.Interfaces.Models.Emergencies
{
    public interface IHealthEmergency : IEmergency
    {
        int NumberOfCasualties { get; }
    }
}
