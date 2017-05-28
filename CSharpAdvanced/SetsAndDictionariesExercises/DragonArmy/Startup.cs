namespace DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int numberOfDragons = int.Parse(Console.ReadLine());
            var dragonsByTypes = new Dictionary<string, Dictionary<string, DragonInfo>>();

            ProcessInput(numberOfDragons, dragonsByTypes);

            PrintAggregatedDragonsInfo(dragonsByTypes);
        }

        private static void ProcessInput(int numberOfDragons, Dictionary<string, Dictionary<string, DragonInfo>> dragonsByTypes)
        {
            for (int i = 0; i < numberOfDragons; i++)
            {
                string[] dragonArgs = Console.ReadLine().Split(' ');

                string type = dragonArgs[0];
                string name = dragonArgs[1];
                int damage = dragonArgs[2].Equals("null") ? 45 : int.Parse(dragonArgs[2]);
                int health = dragonArgs[3].Equals("null") ? 250 : int.Parse(dragonArgs[3]);
                int armor = dragonArgs[4].Equals("null") ? 10 : int.Parse(dragonArgs[4]);

                if (!dragonsByTypes.ContainsKey(type))
                {
                    dragonsByTypes.Add(type, new Dictionary<string, DragonInfo>());
                }

                dragonsByTypes[type][name] = new DragonInfo()
                {
                    Armor = armor,
                    Health = health,
                    Damage = damage
                };
            }
        }

        private static void PrintAggregatedDragonsInfo(Dictionary<string, Dictionary<string, DragonInfo>> dragonsByTypes)
        {
            foreach (var kvp in dragonsByTypes)
            {
                double averageHealth = kvp.Value.Select(x => x.Value).Average(x => x.Health);
                double averageDamage = kvp.Value.Select(x => x.Value).Average(x => x.Damage);
                double averageArmor = kvp.Value.Select(x => x.Value).Average(x => x.Armor);

                Console.WriteLine($"{kvp.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                foreach (var dragonKvp in kvp.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-{dragonKvp.Key} -> damage: {dragonKvp.Value.Damage}, health: {dragonKvp.Value.Health}, armor: {dragonKvp.Value.Armor}");
                }
            }
        }
    }

    public class DragonInfo
    {
        public long Damage { get; set; }
        public long Health { get; set; }
        public long Armor { get; set; }
    }
}
