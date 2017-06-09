namespace NonDigitCount
{
    using System;
    using System.Text.RegularExpressions;

    public class Sstartup
    {
        public static void Main()
        {
            Console.WriteLine("Non-digits: " + Regex.Matches(Console.ReadLine(), "\\D").Count);
        }
    }
}
