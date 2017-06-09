namespace MatchCount
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string targetSubstring = Console.ReadLine();
            MatchCollection matches = Regex.Matches(Console.ReadLine(), Regex.Escape(targetSubstring));
            Console.WriteLine(matches.Count);
        }
    }
}
