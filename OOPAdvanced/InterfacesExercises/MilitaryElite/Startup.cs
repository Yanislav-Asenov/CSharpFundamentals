using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    private static IDictionary<int, IPrivate> privates = new Dictionary<int, IPrivate>();

    public static void Main()
    {
        string inputLine = Console.ReadLine();

        while (inputLine != "End")
        {
            List<string> inputLineArgs = inputLine
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string soldierType = inputLineArgs[0];
            inputLineArgs.RemoveAt(0);

            try
            {
                switch (soldierType)
                {
                    case "Private":
                        ExecutePrivateCommand(inputLineArgs);
                        break;
                    case "LeutenantGeneral":
                        ExecuteLeutenantGeneral(inputLineArgs);
                        break;
                    case "Engineer":
                        ExecuteEngineerCommand(inputLineArgs);
                        break;
                    case "Commando":
                        ExecuteCommandoCommand(inputLineArgs);
                        break;
                    case "Spy":
                        ExecuteSpyCommand(inputLineArgs);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
            }

            inputLine = Console.ReadLine();
        }
    }

    private static void ExecuteSpyCommand(List<string> inputLineArgs)
    {
        int id = int.Parse(inputLineArgs[0]);
        string firstName = inputLineArgs[1];
        string lastName = inputLineArgs[2];
        int codeNumber = int.Parse(inputLineArgs[3]);
        ISpy spy = new Spy(id, firstName, lastName, codeNumber);
        Console.WriteLine(spy.ToString().Trim());
    }

    private static void ExecuteCommandoCommand(List<string> inputLineArgs)
    {
        int id = int.Parse(inputLineArgs[0]);
        string firstName = inputLineArgs[1];
        string lastName = inputLineArgs[2];
        double salary = double.Parse(inputLineArgs[3]);
        string corps = inputLineArgs[4];
        ICommando commando = new Commando(id, firstName, lastName, salary, corps);

        var missionPairs = inputLineArgs.Skip(5).ToList();
        for (int i = 0; i < missionPairs.Count - 1; i += 2)
        {
            try
            {
                string codeName = missionPairs[i];
                string state = missionPairs[i + 1];
                IMission mission = new Mission(codeName, state);
                commando.Missions.Add(mission);
            }
            catch
            {
            }
        }

        Console.WriteLine(commando.ToString().Trim());
    }

    private static void ExecuteEngineerCommand(List<string> inputLineArgs)
    {
        int id = int.Parse(inputLineArgs[0]);
        string firstName = inputLineArgs[1];
        string lastName = inputLineArgs[2];
        double salary = double.Parse(inputLineArgs[3]);
        string corps = inputLineArgs[4];
        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

        var repairPairs = inputLineArgs.Skip(5).ToList();
        for (int i = 0; i < repairPairs.Count - 1; i += 2)
        {
            string partName = repairPairs[i];
            int hours = int.Parse(repairPairs[i + 1]);
            IRepair repair = new Repair(partName, hours);
            engineer.Repairs.Add(repair);
        }

        Console.WriteLine(engineer.ToString());
    }

    private static void ExecuteLeutenantGeneral(List<string> inputLineArgs)
    {
        int id = int.Parse(inputLineArgs[0]);
        string firstName = inputLineArgs[1];
        string lastName = inputLineArgs[2];
        double salary = double.Parse(inputLineArgs[3]);

        ILeutenantGeneral leutenantGeneral = new LeutenantGeneral(id, firstName, lastName, salary);

        var targetPrivateIds = inputLineArgs.Skip(4).Select(int.Parse).ToList();
        foreach (var privateId in targetPrivateIds)
        {
            if (privates.ContainsKey(privateId))
            {
                var targetPrivate = privates[privateId];
                leutenantGeneral.Privates.Add(targetPrivate);
            }
        }

        Console.WriteLine(leutenantGeneral.ToString().Trim());
    }

    private static void ExecutePrivateCommand(List<string> inputLineArgs)
    {
        int id = int.Parse(inputLineArgs[0]);
        string firstName = inputLineArgs[1];
        string lastName = inputLineArgs[2];
        double salary = double.Parse(inputLineArgs[3]);

        IPrivate privateSoldier = new Private(id, firstName, lastName, salary);
        privates.Add(id, privateSoldier);

        Console.WriteLine(privateSoldier.ToString().Trim());
    }
}