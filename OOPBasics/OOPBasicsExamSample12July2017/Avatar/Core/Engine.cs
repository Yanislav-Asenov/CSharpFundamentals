using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private NationsBuilder nationsBuilder;

    public Engine(NationsBuilder nationsBuilder)
    {
        this.nationsBuilder = nationsBuilder;
    }

    public void Run()
    {
        while (true)
        {
            string[] tokens = Console.ReadLine().Split();
            string commandName = tokens[0];

            switch (commandName)
            {
                case "Bender":
                    List<string> benderArgs = tokens.Skip(1).ToList();
                    this.nationsBuilder.AssignBender(benderArgs);
                    break;
                case "Monument":
                    List<string> monumentArgs = tokens.Skip(1).ToList();
                    this.nationsBuilder.AssignMonument(monumentArgs);
                    break;
                case "Status":
                    Console.WriteLine(this.nationsBuilder.GetStatus(tokens[1]));
                    break;
                case "War":
                    this.nationsBuilder.IssueWar(tokens[1]);
                    break;
                case "Quit":
                    Console.WriteLine(this.nationsBuilder.GetWarsRecord());
                    Environment.Exit(0);
                    break;
            }
        }
    }
}