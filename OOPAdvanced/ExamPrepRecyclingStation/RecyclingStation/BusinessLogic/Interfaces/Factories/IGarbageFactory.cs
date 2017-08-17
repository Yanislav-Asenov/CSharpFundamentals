using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.BusinessLogic.Interfaces.Factories
{
    public interface IGarbageFactory
    {
        IWaste Create(string name, double weight, double volumePerKg, string type);
    }
}
