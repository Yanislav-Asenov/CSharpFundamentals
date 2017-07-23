using System.Collections.Generic;

public interface ICustomStack<T> : IEnumerable<T>
{
    void Push(T item);

    T Pop();
}