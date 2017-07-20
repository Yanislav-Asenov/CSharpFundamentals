public class Ferrari : ICar
{
    private const string FerrariModel = "488-Spider";

    private string driver;

    public Ferrari(string driver)
    {
        this.Driver = driver;
    }

    public string Model => FerrariModel;

    public string Driver
    {
        get => this.driver;
        set => this.driver = value;
    }

    public string Gas()
    {
        return "Zadu6avam sA!";
    }

    public string Brake()
    {
        return "Brakes!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.Brake()}/{this.Gas()}/{this.Driver}";
    }
}