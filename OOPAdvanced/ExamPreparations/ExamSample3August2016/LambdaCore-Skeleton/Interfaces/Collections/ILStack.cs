namespace LambdaCore_Skeleton.Interfaces.Collections
{
    using System.Collections.Generic;

    public interface ILStack<T> : IEnumerable<T> where T : class
    {
        int Count();

        T Push(T item);

        void Pop();

        T Peek();

        bool IsEmpty();
    }
}
