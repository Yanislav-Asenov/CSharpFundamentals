using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        SortedSet<Person> sortedHashSet = new SortedSet<Person>();
        HashSet<Person> hashSet = new HashSet<Person>();

        int numberOfInputLines = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfInputLines; i++)
        {
            string[] personArgs = Console.ReadLine().Split();
            string name = personArgs[0];
            int age = int.Parse(personArgs[1]);
            Person person = new Person(name, age);
            sortedHashSet.Add(person);
            hashSet.Add(person);
        }

        Console.WriteLine(sortedHashSet.Count);
        Console.WriteLine(hashSet.Count);
    }
}