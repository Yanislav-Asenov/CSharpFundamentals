namespace FindEvenOrOdds
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Predicate<string> filterEven = filter => filter.ToUpper() == "EVEN";


        }

        public static int[] PrintOddOrEvenNumbers(int[] numbers, Predicate<string> filter)
        {
            if (filter.ToUpper() == "EVEN")
            {
                return numbers.Where((x) => x % 2 == 0).ToArray();
            }
            else
            {
                return numbers.Where((x) => x % 2 == 1).ToArray();
            }
        }
    }
}
