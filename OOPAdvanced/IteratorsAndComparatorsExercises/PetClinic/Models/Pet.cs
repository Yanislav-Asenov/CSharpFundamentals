public class Pet
{
    private string name;
    private int age;
    private string kind;

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

    public string Kind
    {
        get => this.kind;
        set => this.kind = value;
    }
}