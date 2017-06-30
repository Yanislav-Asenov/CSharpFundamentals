namespace BoundedNumbers
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] numberBounds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            double[] resultNumbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .Where(x => x >= numberBounds.Min() && x <= numberBounds.Max())
                .ToArray();

            if (resultNumbers.Length > 0)
            {
                Console.WriteLine(string.Join(" ", resultNumbers));
            }
        }
    }
}
