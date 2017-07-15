public class EarthMonument : Monument
{
    private int earthAffinity;

    public EarthMonument(string name, int earthAffinity)
        : base(name)
    {
        this.earthAffinity = earthAffinity;
    }

    public override int Affinity => this.earthAffinity;
}