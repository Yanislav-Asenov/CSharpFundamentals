namespace Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] matrixDimensions = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            List<List<long?>> matrix = GetMatrix(rows, cols);

            string command = Console.ReadLine();

            while (!command.Equals("Nuke it from orbit"))
            {
                int[] commandArgs = command
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int targetRow = commandArgs[0];
                int targetCol = commandArgs[1];
                int radius = commandArgs[2];

                // Nuke rows.
                int startRow = Math.Max(targetRow - radius, 0);
                long endRow = Math.Min(targetRow + radius, matrix.Count - 1);
                for (int row = startRow; row <= endRow; row++)
                {
                    if (IsCellInMatrix(row, targetCol, matrix))
                    {
                        matrix[row][targetCol] = null;
                    }
                }

                // Nuke cols.
                if (targetRow >= 0 && targetRow < matrix.Count)
                {
                    int startCol = Math.Max(targetCol - radius, 0);
                    int endCol = Math.Min(matrix[targetRow].Count - 1, targetCol + radius);
                    for (int col = startCol; col <= endCol; col++)
                    {
                        if (IsCellInMatrix(targetRow, col, matrix))
                        {
                            matrix[targetRow][col] = null;
                        }
                    }
                }

                FilterDestroyedCells(matrix);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                command = Console.ReadLine();
            }

            //FilterDestroyedCells(matrix);
            PrintMatrix(matrix);
        }

        private static bool IsCellInMatrix(int row, int targetCol, List<List<long?>> matrix)
        {
            return row >= 0 && row < matrix.Count && targetCol >= 0 && targetCol < matrix[row].Count;
        }

        private static void FilterDestroyedCells(List<List<long?>> matrix)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                var currentRow = matrix[row].Where(x => x != null).ToList();

                if (currentRow.Count == 0)
                {
                    matrix.RemoveAt(row);
                }
                else
                {
                    matrix[row] = currentRow;
                }
            }
        }

        private static void PrintMatrix(List<List<long?>> matrix)
        {
            matrix = matrix.Where(x => x.Count > 0).ToList();

            foreach (var row in matrix)
            {
                var currentRow = row.Where(x => x != null);
                Console.WriteLine(string.Join(" ", currentRow));
            }
        }

        public static List<List<long?>> GetMatrix(int rows, int cols)
        {
            List<List<long?>> resultMatrix = new List<List<long?>>();

            int matrixCellValue = 1;
            for (int row = 0; row < rows; row++)
            {
                List<long?> currentRow = new List<long?>();

                for (int col = 0; col < cols; col++)
                {
                    currentRow.Add(matrixCellValue);
                    matrixCellValue++;
                }

                resultMatrix.Add(currentRow);
            }

            return resultMatrix;
        }
    }
}
