namespace LogsAggregator
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var durationsByUser = new SortedDictionary<string, int>();
            var usersIps = new Dictionary<string, SortedSet<string>>();

            int n = int.Parse(Console.ReadLine());

            ParseUsersInfo(durationsByUser, usersIps, n);

            PrintAggregatedInfo(durationsByUser, usersIps);
        }

        private static void PrintAggregatedInfo(SortedDictionary<string, int> durationsByUser, Dictionary<string, SortedSet<string>> usersIps)
        {
            foreach (var durationKvp in durationsByUser)
            {
                Console.WriteLine($"{durationKvp.Key}: {durationKvp.Value} [{string.Join(", ", usersIps[durationKvp.Key])}]");
            }
        }

        private static void ParseUsersInfo(SortedDictionary<string, int> durationsByUser, Dictionary<string, SortedSet<string>> usersIps, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] inputLineArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string ip = inputLineArgs[0].Trim();
                string username = inputLineArgs[1].Trim();
                int duration = int.Parse(inputLineArgs[2].Trim());

                if (!durationsByUser.ContainsKey(username))
                {
                    durationsByUser.Add(username, 0);
                    usersIps.Add(username, new SortedSet<string>());
                }

                durationsByUser[username] += duration;
                usersIps[username].Add(ip);
            }
        }
    }
}
