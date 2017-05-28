namespace UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var userLogs = new SortedDictionary<string, Dictionary<string, int>>();

            ParseLogs(userLogs);

            PrintLogs(userLogs);
        }

        private static void PrintLogs(SortedDictionary<string, Dictionary<string, int>> userLogs)
        {
            foreach (var kvp in userLogs)
            {
                Console.WriteLine($"{kvp.Key}:");

                var formattedIps = kvp.Value.Select(x => $"{x.Key} => {x.Value}");

                Console.WriteLine($"{string.Join(", ", formattedIps)}.");
            }
        }

        private static void ParseLogs(SortedDictionary<string, Dictionary<string, int>> userLogs)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("end"))
                {
                    break;
                }

                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Parse ip address.
                string[] ipArgs = inputArgs[0].Split('=');
                string ip = ipArgs[1];

                // Parse username.
                string[] userArgs = inputArgs[2].Split('=');
                string username = userArgs[1];

                if (!userLogs.ContainsKey(username))
                {
                    userLogs.Add(username, new Dictionary<string, int>());
                }

                if (!userLogs[username].ContainsKey(ip))
                {
                    userLogs[username].Add(ip, 0);
                }

                userLogs[username][ip]++;
            }
        }
    }
}
