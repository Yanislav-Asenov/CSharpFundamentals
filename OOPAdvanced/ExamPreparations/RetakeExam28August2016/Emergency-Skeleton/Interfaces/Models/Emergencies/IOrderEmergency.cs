namespace Emergency_Skeleton.Interfaces.Models.Emergencies
{
    public interface IOrderEmergency : IEmergency
    {
        bool IsSpecialCase { get; }
    }
}
