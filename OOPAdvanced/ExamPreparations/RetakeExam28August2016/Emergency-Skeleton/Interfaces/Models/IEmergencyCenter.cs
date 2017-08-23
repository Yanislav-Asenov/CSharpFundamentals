namespace Emergency_Skeleton.Interfaces.Models
{
    using Emergency_Skeleton.Interfaces.Models.Emergencies;
    using System.Collections.Generic;

    public interface IEmergencyCenter
    {
        string Name { get; }

        int AmountOfMaximumEmergencies { get; }

        IList<IEmergency> ProcessedEmergencies { get; }

        bool IsForRetirement();
    }
}
