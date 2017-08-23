namespace Emergency_Skeleton.Models.EmergencyCenters
{
    public class ServiceCenter : BaseEmergencyCenter
    {
        public ServiceCenter(string name, int amountOfMaximumEmergencies) 
            : base(name, amountOfMaximumEmergencies)
        {
        }
    }
}
