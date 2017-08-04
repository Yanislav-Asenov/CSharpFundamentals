namespace IteratorProblem.Contracts
{
    public interface IListIterator<T>
    {
        bool Move();

        bool HasNext();

        T GetCurrent();
    }
}