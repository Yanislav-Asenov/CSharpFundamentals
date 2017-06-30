namespace CustomComparator
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(" ", Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderBy(x => x)
                .OrderBy(x => Math.Abs(x % 2) == 1)
                .ThenBy(x => Math.Abs(x % 2) == 0)
                .ToArray()));
        }
    }
}
