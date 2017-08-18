using System.Collections.Generic;

public abstract class AbstractCommand : IExecutable
{
    private IList<string> args;
    private IManager manager;

    protected AbstractCommand(IList<string> args, IManager manager)
    {
        this.Args = args;
        this.Manager = manager;
    }

    public IList<string> Args
    {
        get => this.args;
        set => this.args = value;
    }

    public IManager Manager
    {
        get => this.manager;
        set => this.manager = value;
    }

    public abstract string Execute();
}