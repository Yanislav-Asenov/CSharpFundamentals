namespace SquaresInMatrix
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] inputArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = inputArgs[0];
            int cols = inputArgs[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int squaresOfEqualCharsCounter = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (IsSquareOfEqualChars(row, col, matrix))
                    {
                        squaresOfEqualCharsCounter++;
                    }
                }
            }

            Console.WriteLine(squaresOfEqualCharsCounter);
        }

        private static bool IsSquareOfEqualChars(int row, int col, string[,] matrix)
        {
            return matrix[row, col] == matrix[row, col + 1] &&
                matrix[row, col + 1] == matrix[row + 1, col] &&
                matrix[row + 1, col] == matrix[row + 1, col + 1];
        }
    }
}
