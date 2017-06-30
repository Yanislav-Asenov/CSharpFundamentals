namespace MapDistricts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            string[] inputCities = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            long minPopulation = long.Parse(Console.ReadLine());

            Dictionary<string, List<BigInteger>> districtsByCities = new Dictionary<string, List<BigInteger>>();

            foreach (var city in inputCities)
            {
                string[] tokens = city.Split(':');
                string cityName = tokens[0];
                long population = long.Parse(tokens[1]);

                if (!districtsByCities.ContainsKey(cityName))
                {
                    districtsByCities.Add(cityName, new List<BigInteger>());
                }

                districtsByCities[cityName].Add(population);
            }

            StringBuilder result = new StringBuilder();
            foreach (var kvp in districtsByCities.OrderByDescending(x => x.Key))
            {
                BigInteger currentSum = 0;
                foreach (var item in kvp.Value)
                {
                    currentSum += item;
                }

                if (currentSum > minPopulation)
                {
                    result.AppendLine($"{kvp.Key}: {string.Join(" ", kvp.Value.OrderByDescending(x => x).Take(5))}");
                }
            }

            Console.Write(result);
        }
    }
}
