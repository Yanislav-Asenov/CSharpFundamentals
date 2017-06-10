namespace MatchPhoneNumber
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string pattern = "(^\\+359 2 [0-9]{3} [0-9]{4}$)|(^\\+359-2-[0-9]{3}-[0-9]{4}$)";
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
