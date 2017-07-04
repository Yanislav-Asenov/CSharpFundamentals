using System;
using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public string Peek()
    {
        if (this.IsEmpty())
        {
            throw new InvalidOperationException("The collection is empty");
        }

        return this.data[this.data.Count - 1];
    }

    public bool IsEmpty()
    {
        return this.data.Count == 0;
    }

    public string Pop()
    {
        if (this.IsEmpty())
        {
            throw new InvalidOperationException("The collection is empty");
        }

        string itemToReturn = this.data[this.data.Count - 1];
        this.data.RemoveAt(this.data.Count - 1);

        return itemToReturn;
    }

}

