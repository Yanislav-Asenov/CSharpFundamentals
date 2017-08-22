namespace LambdaCore_Skeleton.Core
{
    using LambdaCore_Skeleton.Interfaces.Core;
    using LambdaCore_Skeleton.Interfaces.Factories;
    using LambdaCore_Skeleton.Interfaces.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PlantController : IPlantController
    {
        private HashSet<string> validCoreTypes;
        private HashSet<string> validFragmentTypes;
        private ICore selectedCore;
        private readonly ICoreIdManager idManager;
        private readonly ICoreFactory coreFactory;
        private readonly IFragmentFactory fragmentFactory;
        private IDictionary<string, ICore> coresByName;

        public PlantController(ICoreIdManager nameManager, ICoreFactory coreFactory, IFragmentFactory fragmentFactory)
        {
            this.idManager = nameManager;
            this.coreFactory = coreFactory;
            this.fragmentFactory = fragmentFactory;
            this.coresByName = new Dictionary<string, ICore>();

            this.RegisterCoreTypes();
            this.RegisterFragmentTypes();
        }

        private void RegisterFragmentTypes()
        {
            this.validFragmentTypes = new HashSet<string>()
            {
                "Nuclear",
                "Cooling",
            };
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

            if (this.SelectedCore.Id == id)
            {
                this.SelectedCore = null;
            }

            this.coresByName.Remove(id);
        }

        public void SelectCore(string id)
        {
            if (!this.coresByName.ContainsKey(id))
            {
                throw new ArgumentException($"Core with id {id} not found!");
            }

            this.SelectedCore = this.coresByName[id];
        }

        public IFragment CreateFragment(string type, string name, int pressureAffection)
        {
            if (!this.IsFragmentTypeValid(type))
            {
                throw new ArgumentException("Invalid fragment type");
            }

            if (pressureAffection < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pressureAffection), "PressureAffection must not be negative!");
            }

            IFragment fragment = this.fragmentFactory.CreateFragment(type, name, pressureAffection);

            return fragment;
        }
    
        public void AttachFragment(IFragment fragment)
        {
            if (this.SelectedCore == null)
            {
                throw new InvalidOperationException("No core selected.");
            }

            this.SelectedCore.AttachFragment(fragment);
        }

        public IFragment DetachFragment()
        {
            return this.SelectedCore.DetachFragment();
        }

        public string GetStatus()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Lambda Core Power Plant Status:");
            result.AppendLine($"Total Durability: {this.coresByName.Values.Sum(c => (long) c.Durability)}");
            result.AppendLine($"Total Cores: {this.coresByName.Count}");
            result.AppendLine($"Total Fragments: {this.coresByName.Sum(c => c.Value.TotalNumberOfFragments)}");

            foreach (var core in this.coresByName)
            {
                result.AppendLine(core.Value.ToString());
            }

            return result.ToString().Trim();
        }

        private bool IsCoreTypeValid(string type)
        {
            return this.validCoreTypes.Contains(type);
        }

        private bool IsFragmentTypeValid(string type)
        {
            return this.validFragmentTypes.Contains(type);
        }
    }
}
