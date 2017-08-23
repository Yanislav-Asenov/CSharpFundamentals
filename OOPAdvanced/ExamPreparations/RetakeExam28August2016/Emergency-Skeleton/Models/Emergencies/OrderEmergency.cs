namespace Emergency_Skeleton.Models.Emergencies
{
    using Emergency_Skeleton.Interfaces.Models.Emergencies;
    using Emergency_Skeleton.Interfaces.Utils;

    public class OrderEmergency : BaseEmergency, IOrderEmergency
    {
        private bool isSpecialCase;

        public OrderEmergency(string description, EmergencyLevel emergencyLevel, IRegistrationTime registrationTime, bool isSpecialCase) 
            : base(description, emergencyLevel, registrationTime)
        {
            this.IsSpecialCase = isSpecialCase;
        }

        public bool IsSpecialCase
        {
            get => this.isSpecialCase;
            private set => this.isSpecialCase = value;
        }
    }
}
