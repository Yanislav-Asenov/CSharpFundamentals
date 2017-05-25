namespace ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            long[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
            Stack<long> result = new Stack<long>();

            for (int i = 0; i < numbers.Length; i++)
            {
                result.Push(numbers[i]);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}