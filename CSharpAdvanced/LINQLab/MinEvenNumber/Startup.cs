namespace MinEvenNumber
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            double[] evenNumbers = Console.ReadLine().Split().Select(double.Parse).Where(x => x % 2 == 0).ToArray();

            if (evenNumbers.Length == 0)
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine(evenNumbers.Min().ToString("F2"));
            }
        }
    }
}
