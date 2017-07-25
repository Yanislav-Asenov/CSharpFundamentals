using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
   public  static void Main()
    {
        List<Person> people = new List<Person>();

        string inputLine = Console.ReadLine();
        while (inputLine != "END")
        {
            string[] personArgs = inputLine.Split();
            string name = personArgs[0];
            int age = int.Parse(personArgs[1]);
            string town = personArgs[2];

            Person person = new Person(name, age, town);
            people.Add(person);

            inputLine = Console.ReadLine();
        }

        int targetPersonPosition = int.Parse(Console.ReadLine());
        Person targetPerson = people[targetPersonPosition - 1];

        int numberOfEqualPeople = people.Count(p => targetPerson.CompareTo(p) == 0);
        int numberOfNotEqualPeople = people.Count(p => targetPerson.CompareTo(p) != 0);
        int numberOfTotalPeople = people.Count;

        if (numberOfEqualPeople == 0)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{numberOfEqualPeople} {numberOfNotEqualPeople} {numberOfTotalPeople}");
        }
    }
}