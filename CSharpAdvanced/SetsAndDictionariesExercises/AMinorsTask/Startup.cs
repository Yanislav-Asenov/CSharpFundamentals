namespace AMinorsTask
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var resources = new Dictionary<string, long>();

            string resource = Console.ReadLine();
            while (!resource.Equals("stop"))
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(resource))
                {
                    resources.Add(resource, 0);
                }

                resources[resource] += quantity;

                resource = Console.ReadLine();
            }

            foreach (var kvp in resources)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
