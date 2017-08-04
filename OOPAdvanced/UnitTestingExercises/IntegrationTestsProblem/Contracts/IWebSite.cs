namespace IntegrationTestsProblem.Contracts
{
    using System.Collections.Generic;

    public interface IWebSite
    {
        IDictionary<string, ICategory> Categories { get; }

        IDictionary<string, IUser> Users { get; }

        void AddCategory(ICategory category);

        void AddUser(IUser user);

        ICategory GetCategoryByName(string name);

        IUser GetUserByName(string name);
    }
}