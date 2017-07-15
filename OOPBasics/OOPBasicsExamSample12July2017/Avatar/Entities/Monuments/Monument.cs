public abstract class Monument
{
    private string name;

    protected Monument(string name)
    {
        this.name = name;
    }

    public abstract int Affinity { get; }

    public override string ToString()
    {
        string type = this.GetType().Name.Replace("Monument", string.Empty);
        return $"{type} Monument: {this.name}, {type} Affinity: {this.Affinity}";
    }
}