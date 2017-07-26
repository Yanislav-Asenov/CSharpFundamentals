using System;
using System.Linq;

public class Person : IComparable<Person>
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public int Age
    {
        get => this.age;
        set => this.age = value;
    }

    public int CompareTo(Person other)
    {
        var result = this.Name.CompareTo(other.Name);
        if (result == 0)
        {
            result = this.Age - other.Age;
        }

        return result;
    }

    public override bool Equals(object other)
    {
        var y = other as Person;
        return this.Name == y.Name && this.Age == y.Age;
    }

    public override int GetHashCode()
    {
        var hashCode = this.Name.Length * 10000;
        foreach (var letter in this.Name)
        {
            hashCode += letter;
        }

        hashCode = this.Name.Aggregate(hashCode, (current, letter) => current + letter);
        hashCode += this.Age * 10000000;

        return hashCode;
    }
}