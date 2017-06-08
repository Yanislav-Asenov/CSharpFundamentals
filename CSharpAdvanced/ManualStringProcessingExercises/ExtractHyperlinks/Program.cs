namespace MatchHyperlinks
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string pattern = "<a\\s+([^>]+\\s+)?href\\s*=\\s*('([^']*)'|\"([^ \"]*)|([^\\s>]+))[^>]*>";
            Regex rgx = new Regex(pattern);
            StringBuilder input = new StringBuilder();

            string inputLine = Console.ReadLine();
            while (inputLine != "END")
            {
                input.Append(inputLine);

                inputLine = Console.ReadLine();
            }

            MatchCollection matches = rgx.Matches(input.ToString());

            foreach (Match match in matches)
            {
                string hrefValue = match.Groups[match.Groups.Count - 1].Value;

                if (string.IsNullOrEmpty(hrefValue))
                {
                    hrefValue = match.Groups[match.Groups.Count - 2].Value;
                }

                if (string.IsNullOrEmpty(hrefValue))
                {
                    hrefValue = match.Groups[match.Groups.Count - 3].Value;
                }

                Console.WriteLine(hrefValue);
            }
        }
    }
}
