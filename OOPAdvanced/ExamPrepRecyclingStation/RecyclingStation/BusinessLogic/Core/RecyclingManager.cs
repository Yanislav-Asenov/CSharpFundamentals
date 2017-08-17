namespace RecyclingStation.BusinessLogic.Core
{
    using RecyclingStation.BusinessLogic.Interfaces.Factories;
    using RecyclingStation.Interfaces.Core;
    using RecyclingStation.WasteDisposal.Interfaces;
    using System;

    public class RecyclingManager : IRecyclingManager
    {
        private const string ProccessGarbageMessage = "{0} kg of {1} successfully processed!";
        private const string StatusMessage = "Energy: {0} Capital: {1}";
        private const string ChangeManagementRequirementMessage = "Management requirement changed!";
        private const string ProcessingDeniedMessage = "Processing Denied!";

        private const string FloatingPointNumberFormat = "F2";

        private double energyBalance = 0;
        private double capitalBalance = 0;

        private readonly IGarbageProcessor garbageProcessor;
        private readonly IGarbageFactory garbageFactory;

        private double minimumEnergyBalance;
        private double minimumCapitalBalance;
        private string garbageRequirementType;
        private bool areRequirementsSet;
        
        public RecyclingManager(IGarbageProcessor garbageProcessor, IGarbageFactory garbageFactory)
        {
            this.garbageProcessor = garbageProcessor;
            this.garbageFactory = garbageFactory;
        }

        public string ProcessGarbage(string name, double weight, double volumePerKg, string type)
        {
            if (this.areRequirementsSet)
            {
                if (this.garbageRequirementType.Equals(type, StringComparison.OrdinalIgnoreCase) 
                    && (this.minimumEnergyBalance >= this.energyBalance 
                    || this.minimumCapitalBalance >= this.capitalBalance))
                {
                    return ProcessingDeniedMessage;
                }
            }
        
            IWaste garbage = this.garbageFactory.Create(name, weight, volumePerKg, type);
            IProcessingData data = this.garbageProcessor.ProcessWaste(garbage);

            this.energyBalance += data.EnergyBalance;
            this.capitalBalance += data.CapitalBalance;

            string resultMessage = string.Format(ProccessGarbageMessage,
                garbage.Weight.ToString(FloatingPointNumberFormat),
                garbage.Name);
            return resultMessage;
        }

        public string Status()
        {
            string resultMessage = string.Format(StatusMessage,
                this.energyBalance.ToString(FloatingPointNumberFormat),
                this.capitalBalance.ToString(FloatingPointNumberFormat));
            return resultMessage;
        }

        public string ChangeManagementRequirement(double minimumEnergyBalance, double minimumCapitalBalance, string garbageType)
        {
            this.minimumEnergyBalance = minimumEnergyBalance;
            this.minimumCapitalBalance = minimumCapitalBalance;
            this.garbageRequirementType = garbageType;
            this.areRequirementsSet = true;

            return ChangeManagementRequirementMessage;
        }
    }
}
