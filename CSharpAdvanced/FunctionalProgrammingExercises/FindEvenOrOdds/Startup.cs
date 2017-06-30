namespace FindEvenOrOdds
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] lowerAndUpperBound = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int lowerBound = lowerAndUpperBound[0];
            int upperBound = lowerAndUpperBound[1];

            Predicate<int> isEven = x => x % 2 == 0;
            var resultNumbers = Enumerable.Range(lowerBound, upperBound - lowerBound + 1);

            string filter = Console.ReadLine().ToLower();
            if (filter == "even")
            {
                resultNumbers = resultNumbers.Where(x => isEven(x));
            }
            else
            {
                resultNumbers = resultNumbers.Where(x => !isEven(x));
            }

            Console.WriteLine(string.Join(" ", resultNumbers));
        }
    }
}
