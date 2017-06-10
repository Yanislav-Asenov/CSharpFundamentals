namespace SeriesOfLetters
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string pattern = "([a-zA-Z])\\1+";
            string input = Console.ReadLine();
            string result = Regex.Replace(input, pattern, (match) => match.Groups[1].Value);
            Console.WriteLine(result);
        }
    }
}
