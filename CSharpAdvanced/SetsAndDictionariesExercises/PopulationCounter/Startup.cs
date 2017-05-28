namespace PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var countriesTotalPopulation = new Dictionary<string, long>();
            var countriesAndCitiesPopulation = new Dictionary<string, Dictionary<string, long>>();

            ParsePopulationInfo(countriesAndCitiesPopulation, countriesTotalPopulation);

            PrintReportForPopulation(countriesAndCitiesPopulation, countriesTotalPopulation);
        }

        private static void PrintReportForPopulation(Dictionary<string, Dictionary<string, long>> countriesAndCitiesPopulation, Dictionary<string, long> countriesTotalPopulation)
        {
            foreach (var kvp in countriesTotalPopulation.OrderByDescending(kv => kv.Value))
            {
                Console.WriteLine($"{kvp.Key} (total population: {kvp.Value})");

                foreach (var countryKvp in countriesAndCitiesPopulation[kvp.Key].OrderByDescending(cityKvp => cityKvp.Value))
                {
                    Console.WriteLine($"=>{countryKvp.Key}: {countryKvp.Value}");
                }
            }
        }

        private static void ParsePopulationInfo(Dictionary<string, Dictionary<string, long>> countriesAndCitiesPopulation, Dictionary<string, long> countriesTotalPopulation)
        {
            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine.Equals("report"))
                {
                    break;
                }

                string[] inputLineArgs = inputLine.Split('|');

                string city = inputLineArgs[0];
                string country = inputLineArgs[1];
                long population = long.Parse(inputLineArgs[2]);

                if (!countriesAndCitiesPopulation.ContainsKey(country))
                {
                    countriesAndCitiesPopulation.Add(country, new Dictionary<string, long>());
                    countriesTotalPopulation.Add(country, 0);
                }

                if (!countriesAndCitiesPopulation[country].ContainsKey(city))
                {
                    countriesAndCitiesPopulation[country].Add(city, 0);
                }

                countriesAndCitiesPopulation[country][city] += population;
                countriesTotalPopulation[country] += population;
            }
        }
    }
}
