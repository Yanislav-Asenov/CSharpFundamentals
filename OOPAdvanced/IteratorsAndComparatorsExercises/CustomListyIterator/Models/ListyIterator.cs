using System;
using System.Collections.Generic;

public class ListyIterator<T> : IListyIterator
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
}