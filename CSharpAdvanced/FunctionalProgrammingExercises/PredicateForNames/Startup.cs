namespace PredicateForNames
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int targetLength = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join("\n", 
                Console.ReadLine()
                    .Split()
                    .Where(x => x.Length <= targetLength)));
        }
    }
}
