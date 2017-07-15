using System.Text;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;

    protected Car(
        string brand,
        string model,
        int yearOfProduction,
        int horsepower,
        int acceleration,
        int suspension,
        int durability)
    {
        this.brand = brand;
        this.model = model;
        this.yearOfProduction = yearOfProduction;
        this.horsepower = horsepower;
        this.acceleration = acceleration;
        this.suspension = suspension;
        this.durability = durability;
    }

    public string Brad => this.brand;
    public string Model => this.model;
    public int HorsePower
    {
        get => this.horsepower;
        set => this.horsepower = value;
    }
    public int Acceleration => this.acceleration;
    public int Suspension
    {
        get => this.suspension;
        set => this.suspension = value;
    }
    public int Durability => this.durability;

    public virtual void Tune(int tuneIndex, string addOn)
    {
        this.HorsePower += tuneIndex;
        this.Suspension += (tuneIndex / 2);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"{this.brand} {this.model} {this.yearOfProduction}");
        result.AppendLine($"{this.horsepower} HP, 100 m/h in {this.acceleration} s");
        result.AppendLine($"{this.suspension} Suspension force, {this.durability} Durability");

        return result.ToString();
    }
}