using System;
using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    private IList<int> items;

    public Lake(IList<int> items)
    {
        this.items = items;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.items.Count; i++)
        {
            if (i % 2 == 0)
            {
                yield return this.items[i];
            }
        }

        for (int i = this.items.Count - 1; i >= 0; i--)
        {
            if (i % 2 == 1)
            {
                yield return this.items[i];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}