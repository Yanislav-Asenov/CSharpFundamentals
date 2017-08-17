namespace RecyclingStation.BusinessLogic.Factories
{
    using RecyclingStation.BusinessLogic.Interfaces.Factories;
    using RecyclingStation.WasteDisposal.Interfaces;
    using System;
    using System.Linq;
    using System.Reflection;

    public class GarbageFactory : IGarbageFactory
    {
        private const string GarbageTypeNameSuffix = "Garbage";

        public IWaste Create(string name, double weight, double volumePerKg, string type)
        {
            string targetGarbageTypeName = type + GarbageTypeNameSuffix;

            Type garbageType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.Equals(targetGarbageTypeName, StringComparison.OrdinalIgnoreCase));

            IWaste activatedGarbage = Activator.CreateInstance(garbageType, name, weight, volumePerKg) as IWaste;

            return activatedGarbage;
        }
    }
}
