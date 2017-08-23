namespace Emergency_Skeleton.Interfaces.Models.Emergencies
{
    public interface IPropertyEmergency : IEmergency
    {
        int PropertyDamage { get; }
    }
}
