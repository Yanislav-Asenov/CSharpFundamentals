namespace ExtractEmails
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string pattern = "^|\\s[a-z0-9][\\.\\\\_\\-a-z0-9]*[a-z0-9]@[a-z0-9][\\.\\-a-z0-9]*[a-z0-9]\\.[a-z]{2,}";
            Regex rgx = new Regex(pattern);

            string inputLine = Console.ReadLine();

            StringBuilder input = new StringBuilder();
            while (inputLine.ToUpper() != "END")
            {
                input.AppendLine(inputLine);
                inputLine = Console.ReadLine();
            }

            MatchCollection matches = rgx.Matches(input.ToString());

            StringBuilder result = new StringBuilder();
            foreach (Match match in matches)
            {
                result.AppendLine(match.Value.Trim());
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
