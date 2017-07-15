using System;
using System.Collections.Generic;
using System.Linq;

public class NationsBuilder
{
    private BenderFactory benderFactory;
    private MonumentFactory monumentFactory;
    private Dictionary<string, Nation> nations;
    private IList<string> issuedWars = new List<string>();

    public NationsBuilder()
    {
        this.InitializeNations();
        this.benderFactory = new BenderFactory();
        this.monumentFactory = new MonumentFactory();
    }

    private void InitializeNations()
    {
        nations = new Dictionary<string, Nation>
        {
            { "Air", new AirNation() },
            { "Water", new WaterNation() },
            { "Fire", new FireNation() },
            { "Earth", new EarthNation() },
        };
    }

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        decimal secondaryParameter = decimal.Parse(benderArgs[3]);

        Bender bender = benderFactory.CreateBender(type, name, power, secondaryParameter);
        this.nations[type].AddBender(bender);
    }
    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        string name = monumentArgs[1];
        int affinity = int.Parse(monumentArgs[2]);

        Monument monument = monumentFactory.CreateMonument(type, name, affinity);
        this.nations[type].AddMonument(monument);
    }
    public string GetStatus(string nationsType)
    {
        return nations[nationsType].ToString();
    }
    public void IssueWar(string nationsType)
    {
        this.issuedWars.Add($"War {this.issuedWars.Count + 1} issued by {nationsType}");

        // Add monument bonuses to all nations
        foreach (var nationPair in this.nations)
        {
            nationPair.Value.AddMonumentBonuses();
        }

        // Destroy all defeated nations (destory all monuments and benders)
        foreach (var nationPair in this.nations.OrderByDescending(n => n.Value.TotalPower).Skip(1))
        {
            nationPair.Value.Destroy();
        }
    }
    public string GetWarsRecord()
    {
        return string.Join(Environment.NewLine, this.issuedWars);
    }
}
