using System;
using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(int id, string firstName, string lastName, double salary, string corps) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = new List<IMission>();
    }

    public ICollection<IMission> Missions { get; private set; }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.Append($"{base.ToString()}{Environment.NewLine}Missions:{Environment.NewLine}");

        this.AppendMission(result);

        return result.ToString().Trim();
    }

    private void AppendMission(StringBuilder result)
    {
        foreach (var mission in this.Missions)
        {
            result
                .Append("  " + mission.ToString())
                .AppendLine();
        }
    }
}