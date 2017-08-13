namespace KingsGambit
{
    using KingsGambit.Contracts;
    using KingsGambit.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            IAttackable king = new King(Console.ReadLine());

            string[] royalGuards = Console.ReadLine().Split();
            string[] footmen = Console.ReadLine().Split();

            Dictionary<string, IServant> servantsByName = new Dictionary<string, IServant>();
            foreach (var servantName in royalGuards)
            {
                servantsByName.Add(servantName, new RoyalGuard(servantName, king));
            }
            foreach (var servantName in footmen)
            {
                servantsByName.Add(servantName, new Footman(servantName, king));
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                if (command == "Attack King")
                {
                    king.RespondToAttack();
                }
                else
                {
                    string[] commandArgs = command.Split();
                    string commandName = commandArgs[0];
                    string servantName = commandArgs[1];

                    servantsByName[servantName].Die();
                    servantsByName.Remove(servantName);
                }

                command = Console.ReadLine();
            }
        }
    }
}
