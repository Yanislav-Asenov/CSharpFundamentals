namespace PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<string> names = Console.ReadLine().Split().ToList();

            string command = Console.ReadLine();
            while (command != "Party!")
            {
                string[] commandArgs = command.Split();
                string commandType = commandArgs[0];
                string commandFilterType = commandArgs[1];
                string filter = commandArgs[2];

                switch (commandType)
                {
                    case "Remove":
                        switch (commandFilterType)
                        {
                            case "StartsWith":
                                names = names.Where(x => !x.StartsWith(filter)).ToList();
                                break;
                            case "EndsWith":
                                names = names.Where(x => !x.EndsWith(filter)).ToList();
                                break;
                            case "Length":
                                names = names.Where(x => x.Length != int.Parse(filter)).ToList();
                                break;
                        }
                        break;
                    case "Double":
                        switch (commandFilterType)
                        {
                            case "StartsWith":
                                names.AddRange(names.ToList().Where(x => x.StartsWith(filter)).Distinct());
                                break;
                            case "EndsWith":
                                names.AddRange(names.ToList().Where(x => x.EndsWith(filter)));
                                break;
                            case "Length":
                                names.AddRange(names.ToList().Where(x => x.Length == int.Parse(filter)));
                                break;
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            if (names.Count > 0)
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
