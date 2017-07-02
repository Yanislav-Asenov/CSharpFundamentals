using System;
using System.Collections.Generic;
using System.Linq;
using FootballTeamGenerator;

public class Program
{
    public static void Main()
    {
        Dictionary<string, Team> teamsByName = new Dictionary<string, Team>();
        string inputLine = Console.ReadLine();

        while (inputLine != "END")
        {
            string[] tokens = inputLine.Split(';');
            string command = tokens[0];
            string teamName = tokens[1];

            try
            {
                switch (command)
                {
                    case "Team":
                        teamsByName.Add(teamName, new Team(teamName));
                        break;
                    case "Add":
                        if (!teamsByName.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            inputLine = Console.ReadLine();
                            continue;
                        }

                        string playerName = tokens[2];
                        double endurance = double.Parse(tokens[3]);
                        double sprint = double.Parse(tokens[4]);
                        double dribble = double.Parse(tokens[5]);
                        double passing = double.Parse(tokens[6]);
                        double shooting = double.Parse(tokens[7]);
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        teamsByName[teamName].AddPlayer(player);
                        break;
                    case "Remove":
                        if (!teamsByName.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            inputLine = Console.ReadLine();
                            continue;
                        }

                        string targetPlayerName = tokens[2];
                        teamsByName[teamName].RemovePlayer(targetPlayerName);
                        break;
                    case "Rating":
                        if (!teamsByName.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            inputLine = Console.ReadLine();
                            continue;
                        }
                        Console.WriteLine(teamsByName[teamName]);
                        break;
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
           
            inputLine = Console.ReadLine();
        }
    }
}