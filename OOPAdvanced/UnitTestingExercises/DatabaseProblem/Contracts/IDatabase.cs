namespace DatabaseProblem.Contracts
{
    public interface IDatabase
    {
        int Count { get; }

        void Add(IPerson item);

        IPerson Remove();

        IPerson[] GetAll();

        IPerson FindById(long id);

        IPerson FindByUsername(string username);
    }
}
