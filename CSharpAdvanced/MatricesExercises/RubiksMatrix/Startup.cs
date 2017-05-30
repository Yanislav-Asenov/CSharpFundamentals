namespace RubiksMatrix
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] matrixArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = matrixArgs[0];
            int cols = matrixArgs[1];

            int cellValue = 1;
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = cellValue++;
                }
            }

            var originalMatrix = CopyMatrix(matrix, rows, cols);

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(' ');
                string command = commandArgs[1];
                int targetRowCol = int.Parse(commandArgs[0]);
                int numberOfMoves = int.Parse(commandArgs[2]) % matrix.GetLength(1);

                switch (command)
                {
                    case "up":
                        for (int j = 0; j < numberOfMoves; j++)
                        {
                            ShiftColUp(matrix, targetRowCol);
                        }
                        break;
                    case "right":
                        for (int j = 0; j < numberOfMoves; j++)
                        {
                            ShiftRowRight(matrix, targetRowCol);
                        }
                        break;
                    case "down":
                        for (int j = 0; j < numberOfMoves; j++)
                        {
                            ShiftColDown(matrix, targetRowCol);
                        }
                        break;
                    case "left":
                        for (int j = 0; j < numberOfMoves; j++)
                        {
                            ShiftRowLeft(matrix, targetRowCol);
                        }
                        break;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int targetValue = originalMatrix[row, col];
                    int currentValue = matrix[row, col];

                    if (targetValue != currentValue)
                    {
                        SwitchCells(matrix, currentValue, targetValue, row, col);
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                }
            }

        }

        private static void SwitchCells(int[,] matrix, int currentValue, int targetValue, int startRow, int startCol)
        {
            for (int row = startRow; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int value = matrix[row, col];

                    if (value == targetValue)
                    {
                        Console.WriteLine($"Swap ({startRow}, {startCol}) with ({row}, {col})");
                        matrix[row, col] = currentValue;
                        matrix[startRow, startCol] = targetValue;
                        return;
                    }
                }
            }
        }

        private static void ShiftRowRight(int[,] matrix, int targetRowCol)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] copyMatrix = CopyMatrix(matrix, rows, cols);

            for (int col = 1; col < cols; col++)
            {
                matrix[targetRowCol, col] = copyMatrix[targetRowCol, col - 1];
            }

            matrix[targetRowCol, 0] = copyMatrix[targetRowCol, cols - 1];
        }

        private static void ShiftRowLeft(int[,] matrix, int targetRowCol)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] copyMatrix = CopyMatrix(matrix, rows, cols);

            for (int col = 0; col < cols - 1; col++)
            {
                matrix[targetRowCol, col] = copyMatrix[targetRowCol, col + 1];
            }

            matrix[targetRowCol, cols - 1] = copyMatrix[targetRowCol, 0];
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void ShiftColUp(int[,] matrix, int targetRowCol)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] copyMatrix = CopyMatrix(matrix, rows, cols);

            for (int row = 0; row < rows - 1; row++)
            {
                matrix[row, targetRowCol] = copyMatrix[row + 1, targetRowCol];
            }

            matrix[rows - 1, targetRowCol] = copyMatrix[0, targetRowCol];
        }

        private static void ShiftColDown(int[,] matrix, int targetRowCol)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] copyMatrix = CopyMatrix(matrix, rows, cols);

            for (int row = 1; row < rows; row++)
            {
                matrix[row, targetRowCol] = copyMatrix[row - 1, targetRowCol];
            }

            matrix[0, targetRowCol] = copyMatrix[rows - 1, targetRowCol];
        }

        private static int[,] CopyMatrix(int[,] matrix, int rows, int cols)
        {
            var result = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    result[r, c] = matrix[r, c];
                }
            }

            return result;
        }
    }
}
