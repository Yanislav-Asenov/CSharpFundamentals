using System;
using System.Collections.Generic;

public class Box<T> : IBox<T>
{
    private IList<T> elements = new List<T>();

    public int Count => this.elements.Count;

    public void Add(T element)
    {
        this.elements.Add(element);
    }

    public T Remove()
    {
        if (this.elements.Count == 0)
        {
            throw new InvalidOperationException("Cannot remove an item from an empty collection.");
        }

        var itemToReturn = this.elements[this.Count - 1];
        this.elements.RemoveAt(this.Count - 1);

        return itemToReturn;
    }
}