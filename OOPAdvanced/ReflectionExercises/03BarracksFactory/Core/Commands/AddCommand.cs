using System;

public class AddCommand : Command
{
    [Inject]
    private IRepository repository;

    [Inject]
    private IUnitFactory unitFactory;

    public AddCommand(string[] data) 
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
        IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
        this.repository.AddUnit(unitToAdd);
        string output = unitType + " added!";
        return output;
    }
}