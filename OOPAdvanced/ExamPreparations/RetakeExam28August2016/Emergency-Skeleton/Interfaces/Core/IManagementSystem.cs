namespace Emergency_Skeleton.Interfaces.Core
{
    public interface IManagementSystem
    {
        string RegisterPropertyEmergency();

        string RegisterHealthEmergency();

        string RegisterOrderEmergency();

        string RegisterFireServiceCenter();

        string RegisterMedicalServiceCenter();

        string RegisterPoliceServiceCenter();

        string ProcessEmergencies();

        string EmergencyReport();
    }
}
