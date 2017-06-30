namespace FindAndSumIntegers
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            double[] inputNumbers = Console.ReadLine()
                .Split()
                .Where(x => double.TryParse(x, out double i))
                .Select(double.Parse)
                .ToArray();

            if (inputNumbers.Length > 0)
            {
                Console.WriteLine(inputNumbers.Sum());
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}
