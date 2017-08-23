namespace Emergency_Skeleton.Interfaces.Models.Emergencies
{
    using Emergency_Skeleton.Interfaces.Utils;
    using Emergency_Skeleton.Models.Emergencies;

    public interface IEmergency
    {
        string Description { get; }

        EmergencyLevel EmergencyLevel { get; }

        IRegistrationTime RegistrationTime { get; }
    }
}
