public class Citizen : IPerson, IResident
{
    private string name;
    private string country;
    private int age;

    public Citizen(string name, string country, int age)
    {
        this.name = name;
        this.country = country;
        this.age = age;
    }

    string IPerson.Name { get; }

    string IResident.Name { get; }

    string IResident.Country => this.country;

    int IPerson.Age => this.age;

    string IResident.GetName()
    {
        return $"Mr/Ms/Mrs {this.name}";
    }

    string IPerson.GetName()
    {
        return this.name;
    }
}