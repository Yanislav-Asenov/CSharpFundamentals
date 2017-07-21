using System;
using System.Collections.Generic;

public class AddRemoveCollection : ICollection
{
    private IList<string> elements = new List<string>();

    public int Add(string item)
    {
        this.elements.Insert(0, item);
        return 0;
    }

    public string Remove()
    {
        if (this.elements.Count == 0)
        {
            throw new InvalidOperationException("No items in the collection");
        }

        var itemToReturn = this.elements[this.elements.Count - 1];
        this.elements.RemoveAt(this.elements.Count - 1);

        return itemToReturn;
    }
}