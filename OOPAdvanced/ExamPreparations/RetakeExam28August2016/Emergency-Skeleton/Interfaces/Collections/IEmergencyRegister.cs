namespace Emergency_Skeleton.Interfaces.Collections
{
    using Emergency_Skeleton.Interfaces.Models.Emergencies;

    public interface IEmergencyRegister
    {
        void EnqueueEmergency(IEmergency emergency);

        IEmergency DequeueEmergency();

        IEmergency PeekEmergency();

        bool IsEmpty();
    }
}
