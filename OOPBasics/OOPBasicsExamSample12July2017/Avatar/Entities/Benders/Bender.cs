using System.Numerics;

public abstract class Bender
{
    private string name;
    private decimal power;

    protected Bender(string name, int power)
    {
        this.name = name;
        this.Power = power;
    }

    public virtual decimal Power
    {
        get => this.power;
        set => this.power = value;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name.Replace("Bender", string.Empty)} Bender: {this.name}, Power: {this.power}";
    }
}