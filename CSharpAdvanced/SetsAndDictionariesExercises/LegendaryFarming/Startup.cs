namespace LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var keyMaterials = new Dictionary<string, int>()
            {
                { "shards", 0 },
                { "fragments", 0},
                { "motes", 0 }
            };

            var junkMaterials = new Dictionary<string, int>();

            while (true)
            {
                string[] materials = Console.ReadLine().Split(' ');

                for (int i = 0; i < materials.Length - 1; i += 2)
                {
                    string materialName = materials[i + 1].ToLower();
                    int quantity = int.Parse(materials[i]);

                    if (keyMaterials.ContainsKey(materialName))
                    {
                        keyMaterials[materialName] += quantity;

                        if (keyMaterials[materialName] >= 250)
                        {
                            keyMaterials[materialName] -= 250;
                            Console.WriteLine($"{GetLegendaryNameByMaterial(materialName)} obtained!");

                            PrintKeyMaterials(keyMaterials);
                            PrintJunkMaterials(junkMaterials);
                            return;
                        }
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(materialName))
                        {
                            junkMaterials.Add(materialName, 0);
                        }

                        junkMaterials[materialName] += quantity;
                    }
                }
            }
        }

        private static void PrintJunkMaterials(Dictionary<string, int> junkMaterials)
        {
            foreach (var kvp in junkMaterials.OrderBy(kvp => kvp.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        private static void PrintKeyMaterials(Dictionary<string, int> keyMaterials)
        {
            foreach (var kvp in keyMaterials.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        public static string GetLegendaryNameByMaterial(string materialName)
        {
            string legendaryName = string.Empty;

            switch (materialName)
            {
                case "shards":
                    legendaryName = "Shadowmourne";
                    break;
                case "fragments":
                    legendaryName = "Valanyr";
                    break;
                case "motes":
                    legendaryName = "Dragonwrath";
                    break;
            }

            return legendaryName;
        }
    }
}
