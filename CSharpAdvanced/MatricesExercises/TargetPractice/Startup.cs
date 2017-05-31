namespace TargetPractice
{
    using System;
    using System.Linq;

    public class Statup
    {
        public static void Main()
        {
            int[] matrixDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];
            char[,] matrix = new char[rows, cols];
            string snake = Console.ReadLine();

            FillMatrix(rows, cols, matrix, snake);

            int[] shotParameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int impactRow = shotParameters[0];
            int impactCol = shotParameters[1];
            int radius = shotParameters[2];

            FireShot(matrix, impactRow, impactCol, radius);

            RearrangeMatrix(matrix);

            PrintMatrix(matrix);
        }

        private static void RearrangeMatrix(char[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = matrix.GetLength(0) - 2; row >= 0; row--)
                {
                    char currentChar = matrix[row, col];

                    if (char.IsWhiteSpace(currentChar))
                    {
                        continue;
                    }

                    char previousChar = matrix[row + 1, col];

                    if (char.IsWhiteSpace(previousChar))
                    {
                        int startRow = row;
                        while (startRow < matrix.GetLength(0) - 1 && char.IsWhiteSpace(matrix[startRow + 1, col]))
                        {
                            matrix[startRow + 1, col] = matrix[startRow, col];
                            matrix[startRow, col] = ' ';
                            startRow++;
                        }
                    }
                }
            }
        }

        private static void FireShot(char[,] matrix, int impactRow, int impactCol, int radius)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (IsCellInImpactRadius(row, col, impactRow, impactCol, radius))
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static bool IsCellInImpactRadius(int row, int col, int impactRow, int impactCol, int radius)
        {
            // formula:
            // (x - center_x)^2 + (y - center_y)^2 <= radius^2
            return (row - impactRow) * (row - impactRow) + (col - impactCol) * (col - impactCol) <= radius * radius;
        }

        private static void FillMatrix(int rows, int cols, char[,] matrix, string snake)
        {
            int snakeIndex = 0;
            bool isDirectionLeft = true;
            for (int row = rows - 1; row >= 0; row--)
            {
                if (isDirectionLeft)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[snakeIndex++ % snake.Length];
                    }
                }
                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snake[snakeIndex++ % snake.Length];
                    }
                }

                isDirectionLeft = !isDirectionLeft;
            }
        }

        private static void PrintMatrix(char[,] matrix)
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
