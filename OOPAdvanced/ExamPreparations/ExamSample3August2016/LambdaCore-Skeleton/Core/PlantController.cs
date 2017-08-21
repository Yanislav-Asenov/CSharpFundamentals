namespace LambdaCore_Skeleton.Core
{
    using LambdaCore_Skeleton.Interfaces.Core;
    using LambdaCore_Skeleton.Interfaces.Factories;
    using LambdaCore_Skeleton.Interfaces.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlantController : IPlantController
    {
        private HashSet<string> validCoreTypes;
        private ICore selectedCore;
        private readonly ICoreIdManager idManager;
        private readonly ICoreFactory coreFactory;
        private IDictionary<string, ICore> coresByName;

        public PlantController(ICoreIdManager nameManager, ICoreFactory coreFactory)
        {
            this.idManager = nameManager;
            this.coreFactory = coreFactory;
            this.coresByName = new Dictionary<string, ICore>();

            this.RegisterCoreTypes();
        }

        private void RegisterCoreTypes()
        {
            this.validCoreTypes = new HashSet<string>()
            {
                "System",
                "Para",
            };
        }

        public ICore SelectedCore
        {
            get => this.selectedCore;
            private set => this.selectedCore = value;
        }

        public IDictionary<string, ICore> Cores => this.coresByName.ToDictionary(x => x.Key, x => x.Value);

        public ICore CreateCore(string type, int durability)
        {
            if (!this.IsCoreTypeValid(type))
            {
                throw new ArgumentException("Invalid core type");
            }

            if (durability < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(durability), "Durability must not be negative!");
            }

            string coreId = this.idManager.GetNext().ToString();
            ICore core = this.coreFactory.CreateCore(coreId, type, durability);
            this.coresByName.Add(coreId, core);

            return core;
        }

        public void RemoveCore(string id)
        {
            if (!this.coresByName.ContainsKey(id))
            {
                throw new AggregateException($"Core with id {id} does not exist.");
            }

            this.coresByName.Remove(id);
        }

        private bool IsCoreTypeValid(string type)
        {
            return this.validCoreTypes.Contains(type);
        }
    }
}
