using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    public static void Main()
    {
        Dictionary<string, Person> peopleByName = new Dictionary<string, Person>();

        string inputLine = Console.ReadLine();
        while (inputLine != "End")
        {
            string[] inputLineArgs = inputLine.Split();
            string personName = inputLineArgs[0];
            string command = inputLineArgs[1];

            if (!peopleByName.ContainsKey(personName))
            {
                peopleByName.Add(personName, new Person(personName));
            }

            switch (command)
            {
                case "company":
                    string companyName = inputLineArgs[2];
                    string department = inputLineArgs[3];
                    decimal salary = decimal.Parse(inputLineArgs[4]);
                    peopleByName[personName].Company = new Company(companyName, department, salary);
                    break;
                case "pokemon":
                    string pokemonName = inputLineArgs[2];
                    string pokemonType = inputLineArgs[3];
                    peopleByName[personName].Pokemons.Add(new Pokemon(pokemonName, pokemonType));
                    break;
                case "parents":
                    string parentName = inputLineArgs[2];
                    string parentBirthday = inputLineArgs[3];
                    peopleByName[personName].Parents.Add(new Parent(parentName, parentBirthday));
                    break;
                case "children":
                    string childName = inputLineArgs[2];
                    string childBirthday = inputLineArgs[3];
                    peopleByName[personName].Children.Add(new Child(childName, childBirthday));
                    break;
                case "car":
                    string carModel = inputLineArgs[2];
                    int carSpeed = int.Parse(inputLineArgs[3]);
                    peopleByName[personName].Car = new Car(carModel, carSpeed);
                    break;
            }

            inputLine = Console.ReadLine();
        }

        string targetPerson = Console.ReadLine();
        Console.Write(peopleByName[targetPerson]);
    }
}

public class Person
{
    public string Name { get; set; }
    public Company Company { get; set; }
    public Car Car { get; set; }
    public ICollection<Pokemon> Pokemons { get; set; }
    public ICollection<Parent> Parents { get; set; }
    public ICollection<Child> Children { get; set; }

    public Person(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<Parent>();
        this.Children = new List<Child>();
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        // Append name
        result.AppendLine(this.Name);

        // Append company info
        result.AppendLine("Company:");
        if (this.Company != null)
        {
            result.AppendLine(this.Company.ToString());
        }

        // Append car info
        result.AppendLine("Car:");
        if (this.Car != null)
        {
            result.AppendLine(this.Car.ToString());
        }

        // Append pokemons info
        result.AppendLine("Pokemon:");
        foreach (Pokemon pokemon in this.Pokemons)
        {
            result.AppendLine(pokemon.ToString());
        }

        // Append parents info
        result.AppendLine("Parents:");
        foreach (Parent parent in this.Parents)
        {
            result.AppendLine(parent.ToString());
        }

        // Append children info
        result.AppendLine("Children:");
        foreach (Child child in this.Children)
        {
            result.AppendLine(child.ToString());
        }

        return result.ToString();
    }
}

public class Company
{
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }

    public Company(string name, string department, decimal salary)
    {
        this.Name = name;
        this.Department = department;
        this.Salary = salary;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Department} {this.Salary:F2}";
    }
}

public class Pokemon
{
    public string Name { get; set; }
    public string Type { get; set; }

    public Pokemon(string name, string type)
    {
        this.Name = name;
        this.Type = type;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Type}";
    }
}

public class Parent
{
    public string Name { get; set; }
    public string Birthday { get; set; }

    public Parent(string name, string birthday)
    {
        this.Name = name;
        this.Birthday = birthday;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }
}

public class Child
{
    public string Name { get; set; }
    public string Birthday { get; set; }

    public Child(string name, string birthday)
    {
        this.Name = name;
        this.Birthday = birthday;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }
}

public class Car
{
    public string Model { get; set; }
    public int Speed { get; set; }

    public Car(string model, int speed)
    {
        this.Model = model;
        this.Speed = speed;
    }

    public override string ToString()
    {
        return $"{this.Model} {this.Speed}";
    }
}

