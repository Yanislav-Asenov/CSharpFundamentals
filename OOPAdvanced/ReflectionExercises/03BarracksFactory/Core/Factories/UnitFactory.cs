using System;

public class UnitFactory : IUnitFactory
{
    public IUnit CreateUnit(string unitType)
    {
        try
        {
            Type targetUnitType = Type.GetType(unitType);
            IUnit unitInstance = (IUnit)Activator.CreateInstance(targetUnitType);
            return unitInstance;
        }
        catch
        {
            throw new InvalidOperationException("Invalid unit type!");
        }
    }
}