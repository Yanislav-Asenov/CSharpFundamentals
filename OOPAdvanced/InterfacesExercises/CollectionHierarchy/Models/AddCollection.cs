using System.Collections.Generic;

public class AddCollection : IAddable
{
    private IList<string> elements = new List<string>();

    public int Add(string item)
    {
        if (item is null)
        {
            return -1;
        }

        this.elements.Add(item);
        return this.elements.Count - 1;
    }
}