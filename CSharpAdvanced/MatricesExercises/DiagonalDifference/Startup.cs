namespace DiagonalDifference
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            long rowsCols = long.Parse(Console.ReadLine());
            long[,] matrix = new long[rowsCols, rowsCols];

            for (int row = 0; row < rowsCols; row++)
            {
                long[] currentRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                for (int col = 0; col < rowsCols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            long primaryDiagonalSum = 0;
            for (int row = 0; row < rowsCols; row++)
            {
                primaryDiagonalSum += matrix[row, row];
            }

            long secondaryDiagonalSum = 0;
            for (int row = 0; row < rowsCols; row++)
            {
                secondaryDiagonalSum += matrix[row, rowsCols - row - 1];
            }

            long result = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
            Console.WriteLine(result);
        }
    }
}
