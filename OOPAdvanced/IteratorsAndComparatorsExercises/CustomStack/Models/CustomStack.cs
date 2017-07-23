using System;
using System.Collections;
using System.Collections.Generic;

public class CustomStack<T> : ICustomStack<T>
{
    private IList<T> items;

    public CustomStack()
    {
        this.items = new List<T>();
    }

    public T Pop()
    {
        if (this.items.Count == 0)
        {
            throw new InvalidOperationException("No elements");
        }


        var itemToReturn = this.items[this.items.Count - 1];
        this.items.RemoveAt(this.items.Count - 1);

        return itemToReturn;
    }

    public void Push(T item)
    {
        this.items.Add(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.items.Count - 1; i >= 0; i--)
        {
            yield return this.items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}