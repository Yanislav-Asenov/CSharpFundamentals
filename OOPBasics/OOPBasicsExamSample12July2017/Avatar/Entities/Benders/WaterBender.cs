public class WaterBender : Bender
{
    private decimal waterClarity;

    public WaterBender(string name, int power, decimal waterClarity) 
        : base(name, power)
    {
        this.waterClarity = waterClarity;
    }

    public override decimal Power => base.Power * this.waterClarity;

    public override string ToString()
    {
        return $"{base.ToString()}, Water Clarity: {this.waterClarity:F2}";
    }
}