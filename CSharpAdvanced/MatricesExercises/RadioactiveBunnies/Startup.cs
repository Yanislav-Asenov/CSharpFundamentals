namespace RadioactiveBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int playerRow = -1;
            int playerCol = -1;
            int[] matrixDimensions = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    if (currentRow[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    matrix[row, col] = currentRow[col];
                }
            }

            string commands = Console.ReadLine();
            string resultString = string.Empty;
            bool isGameOver = false;
            string result = string.Empty;
            foreach (var ch in commands)
            {
                int targetRow = playerRow;
                int targetCol = playerCol;
                //var bunnyRows = new Stack<int>();
                //var bunnyCols = new Stack<int>();

                //FillBunnies(matrix, bunnyRows, bunnyCols);

                switch (ch)
                {
                    case 'U':
                        targetRow--;
                        break;
                    case 'R':
                        targetCol++;
                        break;
                    case 'D':
                        targetRow++;
                        break;
                    case 'L':
                        targetCol--;
                        break;
                }

                if (CellsAreInside(rows, cols, targetRow, targetCol))
                {
                    if (matrix[targetRow, targetCol] == 'B')
                    {
                        matrix[playerRow, playerCol] = '.';
                        result = $"dead: {targetRow} {targetCol}";
                        isGameOver = true;
                    }
                    else
                    {
                        matrix[targetRow, targetCol] = 'P';
                        matrix[playerRow, playerCol] = '.';

                        playerRow = targetRow;
                        playerCol = targetCol;
                    }
                }
                else
                {
                    matrix[playerRow, playerCol] = '.';
                    result = $"won: {playerRow} {playerCol}";
                    isGameOver = true;
                }

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            if (row - 1 >= 0)
                            {
                                if (matrix[row - 1, col] == 'P')
                                {
                                    isGameOver = true;
                                    result = $"dead: {row - 1} {col}";
                                }

                                if (matrix[row - 1, col] != 'B')
                                {
                                    matrix[row - 1, col] = '@';
                                }
                            }

                            if (row + 1 < rows)
                            {
                                if (matrix[row + 1, col] == 'P')
                                {
                                    isGameOver = true;
                                    result = $"dead: {row + 1} {col}";
                                }

                                if (matrix[row + 1, col] != 'B')
                                {
                                    matrix[row + 1, col] = '@';
                                }
                            }

                            if (col - 1 >= 0)
                            {
                                if (matrix[row, col - 1] == 'P')
                                {
                                    isGameOver = true;
                                    result = $"dead: {row} {col - 1}";
                                }

                                if (matrix[row, col - 1] != 'B')
                                {
                                    matrix[row, col - 1] = '@';
                                }
                            }

                            if (col + 1 < cols)
                            {
                                if (matrix[row, col + 1] == 'P')
                                {
                                    isGameOver = true;
                                    result = $"dead: {row} {col + 1}";
                                }

                                if (matrix[row, col + 1] != 'B')
                                {
                                    matrix[row, col + 1] = '@';
                                }
                            }
                        }
                    }
                }


                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == '@')
                        {
                            matrix[row, col] = 'B';
                        }
                    }
                }

                if (isGameOver)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine(result);
                    break;
                }
            }
        }

        private static bool CellsAreInside(int rows, int cols, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < rows && targetCol >= 0 && targetCol < cols;
        }

        private static void FillBunnies(char[,] matrix, Stack<int> bunnyRows, Stack<int> bunnyCols)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunnyRows.Push(row);
                        bunnyCols.Push(col);
                    }
                }
            }
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
