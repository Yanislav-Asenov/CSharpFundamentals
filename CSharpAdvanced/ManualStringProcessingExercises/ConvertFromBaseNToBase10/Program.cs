namespace ConvertFromBaseNToBase10
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Program
    {
        public static void Main()
        {
            // Parse input.
            BigInteger[] inputArgs = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
            BigInteger inputBase = inputArgs[0];
            BigInteger inputNumber = inputArgs[1];

            string inputNumberAsString = inputNumber.ToString();
            int currentPower = 0;
            BigInteger resultNumber = 0;
            for (int i = inputNumberAsString.Length - 1; i >= 0; i--)
            {
                BigInteger currentDigit = BigInteger.Parse(inputNumberAsString[i].ToString());
                resultNumber += (currentDigit * (BigInteger)Math.Pow((long)inputBase, currentPower));

                currentPower++;
            }

            Console.WriteLine(resultNumber);
        }
    }
}
