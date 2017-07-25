using System;

public class Person : IComparable<Person>
{
    private string name;
    private int age;
    private string town;

    public Person(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }

    public string Town
    {
        get { return town; }
        set { town = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    public int CompareTo(Person other)
    {
        int nameCompare = this.Name.CompareTo(other.Name);
        if (nameCompare != 0)
        {
            return nameCompare;
        }

        int ageCompare = this.Age.CompareTo(other.Age);
        if (ageCompare != 0)
        {
            return ageCompare;
        }

        int townCompare = this.Town.CompareTo(other.Town);
        return townCompare;
    }
}
