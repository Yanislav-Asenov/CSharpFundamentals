namespace MaximalSum
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
            int[][] matrix = new int[rows][];

            FillMatrix(rows, cols, matrix);

            int maxSum = int.MinValue;
            int maxSumCubeRow = -1;
            int maxSumCuteCol = -1;
            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
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
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = maxSumCubeRow; row <= maxSumCubeRow + 2; row++)
            {
                for (int col = maxSumCuteCol; col <= maxSumCuteCol + 2; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static int GetCubeSum(int row, int col, int[][] matrix)
        {
            int sum = 0;
            for (int rowIndex = row; rowIndex <= row + 2; rowIndex++)
            {
                for (int colIndex = col; colIndex <= col + 2; colIndex++)
                {
                    sum += matrix[rowIndex][colIndex];
                }
            }

            return sum;
        }

        private static void FillMatrix(int rows, int cols, int[][] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

        }
    }
}
