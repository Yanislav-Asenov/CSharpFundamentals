namespace ConvertFromBase10ToBaseN
{
    using System;
    using System.Numerics;
    using System.Text;

    class Startup
    {
        static void Main(string[] args)
        {
            string[] inputArgs = Console.ReadLine().Split();
            int targetBase = int.Parse(inputArgs[0]);
            BigInteger number = BigInteger.Parse(inputArgs[1]);

            StringBuilder sb = new StringBuilder();
            while (number > 0)
            {
                sb.Append(number % targetBase);
                number /= targetBase;
            }

            char[] res = sb.ToString().ToCharArray();
            Array.Reverse(res);
            Console.WriteLine(new string(res));
        }
    }
}
