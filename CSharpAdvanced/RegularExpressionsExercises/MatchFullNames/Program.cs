namespace MatchFullNames
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string pattern = "^[A-Z]{1}[a-z]+? [A-Z]{1}[a-z]+?$";
            Regex rgx = new Regex(pattern);

            string input = Console.ReadLine();

            while (input.ToUpper() != "END")
            {
                if (rgx.IsMatch(input))
                {
                    Console.WriteLine(input);
                }

                input = Console.ReadLine();
            }
        }
    }
}
