namespace UpperStrings
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(" ", Console.ReadLine().Split().Select(x => x.ToUpper())));
        }
    }
}
