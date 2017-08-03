public abstract class Command : IExecutable
{
    private string[] data;

    protected Command(string[] data)
    {
        this.data = data;
    }

    protected string[] Data
    {
        get => this.data;
        set => this.data = value;
    }

    public abstract string Execute();
}