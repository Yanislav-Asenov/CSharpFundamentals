namespace ValidTime
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string time = Console.ReadLine();

            Regex regex = new Regex(@"^(0[0-9]|1[012]):[0-5][0-9]:[0-5][0-9] [AP]M$");

            while (time != "END")
            {
                Match match = regex.Match(time);

                if (match.Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                time = Console.ReadLine();
            }
        }
    }
}
