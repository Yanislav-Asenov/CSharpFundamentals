namespace FixEmails
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class Startup
    {
        public static void Main()
        {
            string name = Console.ReadLine();

            var users = new Dictionary<string, string>();
            while (!name.Equals("stop"))
            {
                string email = Console.ReadLine();

                if (email.EndsWith("us", false, CultureInfo.InvariantCulture) ||
                    email.EndsWith("uk", false, CultureInfo.InvariantCulture))
                {
                    name = Console.ReadLine();
                    continue;
                }

                users[name] = email;

                name = Console.ReadLine();
            }

            foreach (var kvp in users)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
