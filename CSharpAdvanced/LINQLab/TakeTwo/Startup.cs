namespace TakeTwo
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] resultNumbers = Console.ReadLine()
                .Split()
                .Distinct()
                .Select(int.Parse)
                .Where(x => x >= 10 && x <= 20)
                .Take(2)
                .ToArray();

            Console.WriteLine(string.Join(" ", resultNumbers));
        }
    }
}
