namespace DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var inputNumber = long.Parse(Console.ReadLine());

            var result = ConvertToBinary(inputNumber);

            Console.WriteLine(result);
        }

        private static string ConvertToBinary(long inputNumber)
        {
            if (inputNumber == 0)
            {
                return inputNumber.ToString();
            }

            var resultDigits = new Stack<long>();

            while (inputNumber > 0)
            {
                resultDigits.Push(inputNumber % 2);
                inputNumber /= 2;
            }

            return string.Join("", resultDigits);
        }
    }
}
