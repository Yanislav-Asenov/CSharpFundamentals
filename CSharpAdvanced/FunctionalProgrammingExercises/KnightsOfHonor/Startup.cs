namespace KnightsOfHonor
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            Action<string> appendSir = names => Console.WriteLine(string.Join("\n", Regex.Split(names, "\\s+").Select(x => "Sir " + x)));
            appendSir(Console.ReadLine());
        }
    }
}
