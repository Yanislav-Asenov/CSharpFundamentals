namespace Emergency_Skeleton.Models.Emergencies
{
    using Emergency_Skeleton.Interfaces.Models.Emergencies;
    using Emergency_Skeleton.Interfaces.Utils;

    public class PropertyEmergency : BaseEmergency, IPropertyEmergency
    {
        private int propertyDamage;

        public PropertyEmergency(string description, EmergencyLevel emergencyLevel, IRegistrationTime registrationTime, int propertyDamage) 
            : base(description, emergencyLevel, registrationTime)
        {
            this.PropertyDamage = propertyDamage;
        }

        public int PropertyDamage
        {
            get => this.propertyDamage;
            private set => this.propertyDamage = value;
        }
    }
}
