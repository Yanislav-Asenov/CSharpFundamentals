namespace Emergency_Skeleton.Models.Emergencies
{
    using Emergency_Skeleton.Interfaces.Models.Emergencies;
    using Emergency_Skeleton.Interfaces.Utils;

    public class HealthEmergency : BaseEmergency, IHealthEmergency
    {
        private int numberOfCasualties;

        public HealthEmergency(string description, EmergencyLevel emergencyLevel, IRegistrationTime registrationTime, int numberOfCasualties) 
            : base(description, emergencyLevel, registrationTime)
        {
            this.NumberOfCasualties = numberOfCasualties;
        }

        public int NumberOfCasualties
        {
            get => this.numberOfCasualties;
            private set => this.numberOfCasualties = value;
        }
    }
}
