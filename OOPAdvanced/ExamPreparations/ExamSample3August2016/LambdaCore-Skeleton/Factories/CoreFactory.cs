namespace LambdaCore_Skeleton.Factories
{
    using LambdaCore_Skeleton.Interfaces.Factories;
    using LambdaCore_Skeleton.Interfaces.Models;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CoreFactory : ICoreFactory
    {
        private const string CoreTypeSuffix = "Core";

        public ICore CreateCore(string id, string type, int durability)
        {
            string coreTypeAsString = type + CoreTypeSuffix;
            var coreType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == coreTypeAsString);

            ICore coreInstance = Activator.CreateInstance(coreType, id, type, durability) as ICore;

            return coreInstance;
        }
    }
}
