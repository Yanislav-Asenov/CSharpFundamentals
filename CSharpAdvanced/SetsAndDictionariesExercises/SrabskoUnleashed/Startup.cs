namespace SrabskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            var singersByVenues = new Dictionary<string, Dictionary<string, long>>();

            ProcessVanuesInfo(singersByVenues);

            PrintAggregatedInfo(singersByVenues);
        }

        private static void ProcessVanuesInfo(Dictionary<string, Dictionary<string, long>> singersByVenues)
        {
            string pattern = @"^(.+?)\s@(.+?)\s(\d+?)\s(\d+)$";
            Regex rgx = new Regex(pattern);

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine.Equals("End"))
                {
                    break;
                }

                var match = rgx.Match(inputLine);

                if (!match.Success)
                {
                    continue;
                }

                // Parse venue and singer.
                string singer = match.Groups[1].Value;
                string venue = match.Groups[2].Value;

                if (singer.Split(' ').Length > 3 || venue.Split(' ').Length > 3)
                {
                    continue;
                }

                // Parse tickets price and quantity.
                long ticketPrice = long.Parse(match.Groups[3].Value);
                long ticketsCount = long.Parse(match.Groups[4].Value);

                if (!singersByVenues.ContainsKey(venue))
                {
                    singersByVenues.Add(venue, new Dictionary<string, long>());
                }

                if (!singersByVenues[venue].ContainsKey(singer))
                {
                    singersByVenues[venue].Add(singer, 0);
                }

                singersByVenues[venue][singer] += ticketsCount * ticketPrice;
            }
        }

        private static void PrintAggregatedInfo(Dictionary<string, Dictionary<string, long>> singersByVenues)
        {
            foreach (var kvp in singersByVenues)
            {
                Console.WriteLine(kvp.Key);

                foreach (var singersKvp in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singersKvp.Key} -> {singersKvp.Value}");
                }
            }
        }
    }
}
