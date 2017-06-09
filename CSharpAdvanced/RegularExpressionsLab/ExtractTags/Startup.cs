namespace ExtractTags
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                MatchCollection matches = Regex.Matches(inputLine, "<.+?>");

                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Groups[0].Value);
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}
