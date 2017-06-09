namespace ValidUsernames
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
                if (Regex.IsMatch(inputLine, "^[a-zA-Z0-9-_]{3,16}$"))
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}
