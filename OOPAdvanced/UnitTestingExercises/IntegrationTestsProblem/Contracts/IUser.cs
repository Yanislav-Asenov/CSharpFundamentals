namespace IntegrationTestsProblem.Contracts
{
    using System.Collections.Generic;

    public interface IUser
    {
        string Name { get; }

        IEnumerable<ICategory> Categories { get; }
    }
}