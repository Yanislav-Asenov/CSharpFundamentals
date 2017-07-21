using System;

public class Box<T> where T : IComparable<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public override string ToString()
    {
        return $"{this.value.GetType().FullName}: {this.value}";
    }

    public int CompareTo(T element)
    {
        return this.value.CompareTo(element);
    }
}