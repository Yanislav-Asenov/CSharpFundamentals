namespace IntegrationTestsProblem.Contracts
{
    using System.Collections.Generic;

    public interface ICategory
    {
        string Name { get; }

        IEnumerable<IUser> Users { get; }

        IEnumerable<ICategory> Subcategories { get; }

        void AddSubcategory(ICategory category);
    }
}
