namespace RecursiveFibonacci
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static Dictionary<long, long> CachedFibNumbers = new Dictionary<long, long>()
        {
            { 1, 1 },
            { 2, 1 }
        };

        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(n));
        }

        public static long GetFibonacci(long n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            if (!CachedFibNumbers.ContainsKey(n))
            {
                CachedFibNumbers.Add(n, GetFibonacci(n - 1) + GetFibonacci(n - 2));
            }

            return CachedFibNumbers[n];
        }
    }
}
