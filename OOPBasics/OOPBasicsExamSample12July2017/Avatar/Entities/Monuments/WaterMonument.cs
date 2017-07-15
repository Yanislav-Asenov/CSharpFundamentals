public class WaterMonument : Monument
{
    private int waterAffinity;

    public WaterMonument(string name, int waterAffinity)
        : base(name)
    {
        this.waterAffinity = waterAffinity;
    }

    public override int Affinity => this.waterAffinity;
}