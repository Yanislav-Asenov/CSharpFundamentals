using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IListyIterator, IEnumerable<T>
{
    private IList<T> elements;
    private int currentIndex;

    public ListyIterator(IList<T> elements)
    {
        this.elements = elements;
        this.currentIndex = 0;
    }

    public bool HasNext()
    {
        return this.currentIndex + 1 < this.elements.Count;
    }

    public bool Move()
    {
        if (this.HasNext())
        {
            this.currentIndex++;
            return true;
        }

        return false;
    }

    public void Print()
    {
        if (this.elements.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(this.elements[this.currentIndex]);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.elements.Count; i++)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}