public class FireBender : Bender
{
    private decimal heatAggression;

    public FireBender(string name, int power, decimal heatAggression) 
        : base(name, power)
    {
        this.heatAggression = heatAggression;
    }

    public override decimal Power => base.Power * this.heatAggression;

    public override string ToString()
    {
        return $"{base.ToString()}, Heat Aggression: {this.heatAggression:F2}";
    }
}