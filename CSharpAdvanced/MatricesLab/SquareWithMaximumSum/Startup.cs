namespace SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] inputArgs = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = inputArgs[0];
            int cols = inputArgs[1];
            int[][] matrix = new int[rows][];

            FillMatrix(rows, cols, matrix);

            int maxSum = int.MinValue;
            int maxSumCubeRow = -1;
            int maxSumCuteCol = -1;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int currentSum = GetCubeSum(row, col, matrix);
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxSumCubeRow = row;
                        maxSumCuteCol = col;
                    }
                }
            }

            PrintMaxSumCube(matrix, maxSum, maxSumCubeRow, maxSumCuteCol);
        }

        private static void PrintMaxSumCube(int[][] matrix, int maxSum, int maxSumCubeRow, int maxSumCuteCol)
        {
            Console.WriteLine($"{matrix[maxSumCubeRow][maxSumCuteCol]} {matrix[maxSumCubeRow][maxSumCuteCol + 1]}");
            Console.WriteLine($"{matrix[maxSumCubeRow + 1][maxSumCuteCol]} {matrix[maxSumCubeRow + 1][maxSumCuteCol + 1]}");
            Console.WriteLine(maxSum);
        }

        private static int GetCubeSum(int row, int col, int[][] matrix)
        {
            int topLeftCell = matrix[row][col];
            int topRightCell = matrix[row][col + 1];
            int bottomLeftCell = matrix[row + 1][col];
            int bottomRightCell = matrix[row + 1][col + 1];

            return topLeftCell + topRightCell + bottomLeftCell + bottomRightCell;
        }

        private static void FillMatrix(int rows, int cols, int[][] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row] = currentRow;
                }
            }
        }
    }
}
