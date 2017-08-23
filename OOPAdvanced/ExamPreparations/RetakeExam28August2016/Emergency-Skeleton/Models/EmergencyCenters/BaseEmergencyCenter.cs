namespace Emergency_Skeleton.Models.EmergencyCenters
{
    using Emergency_Skeleton.Interfaces.Models;
    using Emergency_Skeleton.Interfaces.Models.Emergencies;
    using System.Collections.Generic;

    public abstract class BaseEmergencyCenter : IEmergencyCenter
    {
        private string name;

        private int amountOfMaximumEmergencies;

        private IList<IEmergency> processedEmergencies;

        protected BaseEmergencyCenter(string name, int amountOfMaximumEmergencies)
        {
            this.Name = name;
            this.AmountOfMaximumEmergencies = amountOfMaximumEmergencies;
            this.ProcessedEmergencies = new List<IEmergency>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public int AmountOfMaximumEmergencies
        {
            get
            {
                return this.amountOfMaximumEmergencies;
            }
            private set
            {
                this.amountOfMaximumEmergencies = value;
            }
        }

        public IList<IEmergency> ProcessedEmergencies
        {
            get => this.processedEmergencies;
            private set => this.processedEmergencies = value;
        }

        public bool IsForRetirement()
        {
            return this.ProcessedEmergencies.Count >= this.AmountOfMaximumEmergencies;
        }
    }
}
