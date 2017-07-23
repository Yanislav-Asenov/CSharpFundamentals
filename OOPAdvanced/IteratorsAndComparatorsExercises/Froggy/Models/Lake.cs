using System;
using System.Collections;
using System.Collections.Generic;

public class Lake<T> : IEnumerable<T>
{
    private IList<T> items;

    public Lake(IList<T> items)
    {
        this.items = items;
    }

    public IEnumerator<T> GetEnumerator()
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
        throw new NotImplementedException();
    }
}