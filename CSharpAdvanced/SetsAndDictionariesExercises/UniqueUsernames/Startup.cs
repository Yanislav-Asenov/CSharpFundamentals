namespace UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var uniqueNames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string currentName = Console.ReadLine();
                uniqueNames.Add(currentName);
            }

            Console.WriteLine(string.Join($"{Environment.NewLine}", uniqueNames));
        }
    }
}
