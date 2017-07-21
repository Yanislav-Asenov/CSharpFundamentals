using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
{
    private IList<T> elements = new List<T>();

    public IEnumerable<T> Elements => this.elements;

    public int Count { get => this.elements.Count; }

    public T this[int index] => this.elements[index];

    public void Add(T element)
    {
        this.elements.Add(element);
    }

    public bool Contains(T element)
    {
        return this.elements.Contains(element);
    }

    public int CountGreaterThan(T element)
    {
        return this.elements.Count(e => e.CompareTo(element) > 0);
    }

    public T Max()
    {
        return this.elements.Max();
    }

    public T Min()
    {
        return this.elements.Min();
    }

    public T Remove(int index)
    {
        var elementToReturn = this.elements[index];
        this.elements.RemoveAt(index);
        return elementToReturn;
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        var firstIndexElement = this.elements[firstIndex];
        this.elements[firstIndex] = this.elements[secondIndex];
        this.elements[secondIndex] = firstIndexElement;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
