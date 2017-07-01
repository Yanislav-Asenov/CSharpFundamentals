using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Family family = new Family();
        for (int i = 0; i < n; i++)
        {
            string[] personArgs = Console.ReadLine().Split();
            string name = personArgs[0];
            int age = int.Parse(personArgs[1]);
            var person = new Person(name, age);
            family.AddMember(person);
        }

        family.PrintPeople(person => person.Age > 30);
    }
}

public class Person
{
    private string name;
    private int age;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }
    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
        }
    }

    public Person()
        : this("No name", 1)
    {
    }

    public Person(int age)
        : this("No name", age)
    {
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Age}";
    }
}

public class Family
{
    private List<Person> members;

    public Family()
    {
        this.members = new List<Person>();
    }

    public void AddMember(Person member)
    {
        this.members.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.members.OrderByDescending(p => p.Age).FirstOrDefault();
    }
    public void PrintPeople(Func<Person, bool> ageFilter)
    {
        foreach (var person in this.members.Where(ageFilter).OrderBy(x => x.Name))
        {
            Console.WriteLine(person);
        }
    }
}