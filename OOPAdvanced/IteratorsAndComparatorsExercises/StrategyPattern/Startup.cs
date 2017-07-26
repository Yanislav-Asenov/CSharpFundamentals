using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        SortedSet<Person> nameComparedPeople = new SortedSet<Person>(new PersonNameComparator());
        SortedSet<Person> ageComparedPeople = new SortedSet<Person>(new PersonAgeComparator());

        int numberOfInputLines = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfInputLines; i++)
        {
            string[] personArgs = Console.ReadLine().Split();
            string name = personArgs[0];
            int age = int.Parse(personArgs[1]);
            Person person = new Person(name, age);
            nameComparedPeople.Add(person);
            ageComparedPeople.Add(person);
        }

        foreach (var person in nameComparedPeople)
        {
            Console.WriteLine(person);
        }

        foreach (var person in ageComparedPeople)
        {
            Console.WriteLine(person);
        }
    }
}