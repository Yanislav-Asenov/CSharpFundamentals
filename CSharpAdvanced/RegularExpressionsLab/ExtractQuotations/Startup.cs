namespace ExtractQuotations
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        static void Main()
        {
            string pattern = @"'(.+?)'|""(.+?)""";
            MatchCollection matches = Regex.Matches(Console.ReadLine(), pattern, RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                if (match.Groups[2].Value == string.Empty)
                {
                    Console.WriteLine(match.Groups[1].Value);
                }
                else
                {
                    Console.WriteLine(match.Groups[2].Value);
                }
            }
        }
    }
}
