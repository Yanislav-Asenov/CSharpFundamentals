namespace GroupNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            const int dividor = 3;
            int[] inputNumbers = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int row = 0; row < dividor; row++)
            {
                List<int> currentRow = new List<int>();
                for (int i = 0; i < inputNumbers.Length; i++)
                {
                    if (Math.Abs(inputNumbers[i] % dividor) == row)
                    {
                        currentRow.Add(inputNumbers[i]);
                    }
                }

                Console.WriteLine(string.Join(" ", currentRow));
            }
        }
    }
}
