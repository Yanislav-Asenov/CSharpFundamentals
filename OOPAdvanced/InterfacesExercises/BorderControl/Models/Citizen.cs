public class Citizen : ICitizen
{
    private const int CitizenFoodIncreasement = 10;

    private string id;
    private string name;
    private int age;
    private string birthdate;
    private int food = 0;

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
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

    public string Id
    {
        get => this.id;
        set => this.id = value;
    }

    public string Birthdate
    {
        get => this.birthdate;
        set => this.birthdate = value;
    }

    public int Food
    {
        get => this.food;
        set => this.food = value;
    }

    public void BuyFood()
    {
        this.Food += CitizenFoodIncreasement;
    }
}