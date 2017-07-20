public class Rebel : IRebel
{
    private const int RebelFoodIncreasement = 5;

    private string name;
    private string group;
    private int age;
    private int food;

    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
    }

    public int Food
    {
        get => this.food;
        set => this.food = value;
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

    public string Group
    {
        get => this.group;
        set => this.group = value;
    }

    public void BuyFood()
    {
        this.Food += RebelFoodIncreasement;
    }
}