namespace LambdaCore_Skeleton.Factories
{
    using LambdaCore_Skeleton.Interfaces.Factories;
    using LambdaCore_Skeleton.Interfaces.Models;
    using System;
    using System.Linq;
    using System.Reflection;

    public class FragmentFactory : IFragmentFactory
    {
        private const string CoreTypeSuffix = "Fragment";

        public IFragment CreateFragment(string type, string name, int pressureAffection)
        {
            string fragmentTypeAsString = type + CoreTypeSuffix;
            var fragmentType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == fragmentTypeAsString);

            IFragment fragmentInstance = Activator.CreateInstance(fragmentType, name, pressureAffection) as IFragment;

            return fragmentInstance;
        }
    }
}
