public class AirBender : Bender
{
    private decimal aerialIntegrity;

    public AirBender(string name, int power, decimal aerialIntegrity) 
        : base(name, power)
    {
        this.aerialIntegrity = aerialIntegrity;
    }

    public override decimal Power => base.Power * this.aerialIntegrity;

    public override string ToString()
    {
        return $"{base.ToString()}, Aerial Integrity: {this.aerialIntegrity:F2}";
    }
}