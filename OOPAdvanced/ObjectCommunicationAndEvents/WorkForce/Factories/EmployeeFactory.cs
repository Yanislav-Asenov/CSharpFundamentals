using System;

public class EmployeeFactory
{
    public IEmployee Create(string type, string name)
    {
        switch (type)
        {
            case "StandartEmployee":
                return new StandartEmployee(name);
            case "PartTimeEmployee":
                return new PartTimeEmployee(name);
            default:
                throw new ArgumentException("Invalid employee type!");
        }
    }
}