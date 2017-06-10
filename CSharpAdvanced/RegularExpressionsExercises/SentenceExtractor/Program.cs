namespace SentenceExtractor
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string pattern = ".+?(\\!|\\.|\\?)";
            string keyWord = Console.ReadLine();
            string text = Console.ReadLine();

            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
                if (Regex.IsMatch(match.Value, $@"\b{keyWord}\b"))
                {
                    Console.WriteLine(match.Value.Trim());
                }
            }
        }
    }
}