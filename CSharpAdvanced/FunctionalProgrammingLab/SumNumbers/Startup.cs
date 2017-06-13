namespace SumNumbers
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Aggregate((a, b) => a + b));
        }
    }
}
