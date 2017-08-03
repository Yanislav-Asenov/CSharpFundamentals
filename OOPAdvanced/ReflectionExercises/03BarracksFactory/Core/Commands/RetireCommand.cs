using System;

public class RetireCommand : Command
{
    [Inject]
    private IRepository repository;

    public RetireCommand(string[] data) 
        : base(data)
    {
    }

    public override string Execute()
    {
        if (this.Data.Length != 2)
        {
            throw new InvalidOperationException("Invalid command!");
        }

        string unitType = this.Data[1];
        this.repository.RemoveUnit(unitType);
        string output = unitType + " retired!";
        return output;
    }
}