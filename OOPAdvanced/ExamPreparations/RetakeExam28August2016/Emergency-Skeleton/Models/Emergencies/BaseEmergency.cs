namespace Emergency_Skeleton.Models.Emergencies
{
    using Emergency_Skeleton.Interfaces.Models.Emergencies;
    using Emergency_Skeleton.Interfaces.Utils;

    public abstract class BaseEmergency : IEmergency
    {
        private string description;

        private EmergencyLevel emergencyLevel;

        private IRegistrationTime registrationTime;

        protected BaseEmergency(string description, EmergencyLevel emergencyLevel, IRegistrationTime registrationTime)
        {
            this.Description = description;
            this.EmergencyLevel = emergencyLevel;
            this.RegistrationTime = registrationTime;
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            private set
            {
                this.description = value;
            }
        }

        public EmergencyLevel EmergencyLevel
        {
            get
            {
                return this.emergencyLevel;
            }
            private set
            {
                this.emergencyLevel = value;
            }
        }

        public IRegistrationTime RegistrationTime
        {
            get
            {
                return this.registrationTime;
            }
            private set
            {
                this.registrationTime = value;
            }
        }
    }
}
