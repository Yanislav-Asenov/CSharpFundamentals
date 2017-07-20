using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(int id, string firstName, string lastName, double salary, string corps) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = new List<IRepair>();
    }

    public ICollection<IRepair> Repairs { get; private set; }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.Append($"{base.ToString()}{Environment.NewLine}Repairs:{Environment.NewLine}");

        this.AppendRepairs(result);

        return result.ToString().Trim();
    }

    private void AppendRepairs(StringBuilder result)
    {
        foreach (var repair in this.Repairs)
        {
            result
                .Append("  " + repair.ToString())
                .AppendLine();
        }
    }
}