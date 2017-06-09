namespace ExtractIntegerNumbers
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            MatchCollection matches = Regex.Matches(Console.ReadLine(), "[0-9]+");

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[0].Value);
            }
        }
    }
}
