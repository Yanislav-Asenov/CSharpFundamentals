namespace StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            int i;
            int targetRotation = Console.ReadLine()
                .Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => int.TryParse(x, out i))
                .Select(int.Parse)
                .FirstOrDefault() % 360;

            var matrix = new List<string>();
            string inputLine = Console.ReadLine().Trim();
            while (inputLine != "END")
            {
                matrix.Add(inputLine);

                inputLine = Console.ReadLine();
            }

            switch (targetRotation)
            {
                case 0:
                    PrintMatrixWithRotation0(matrix);
                    break;
                case 90:
                    PrintMatrixWithRotation90(matrix);
                    break;
                case 180:
                    PrintMatrixWithRotation180(matrix);
                    break;
                case 270:
                    PrintMatrixWithRotation270(matrix);
                    break;
            }
        }

        private static void PrintMatrixWithRotation270(List<string> matrix)
        {
            int maxCol = matrix.Max(x => x.Length);
            int col = maxCol - 1;
            while (col >= 0)
            {
                for (int row = 0; row < matrix.Count; row++)
                {
                    if (col < matrix[row].Length)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }

                Console.WriteLine();
                col--;
            }
        }

        private static void PrintMatrixWithRotation180(List<string> matrix)
        {
            int maxCol = matrix.Max(x => x.Length);
            for (int row = matrix.Count - 1; row >= 0; row--)
            {
                Console.WriteLine(new string(matrix[row].Reverse().ToArray()).PadLeft(maxCol));
            }
        }

        private static void PrintMatrixWithRotation90(List<string> matrix)
        {
            int maxCol = matrix.Max(x => x.Length);
            int col = 0;
            while (col < maxCol)
            {
                for (int row = matrix.Count - 1; row >= 0; row--)
                {
                    if (col < matrix[row].Length)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }

                Console.WriteLine();
                col++;
            }
        }

        private static void PrintMatrixWithRotation0(List<string> matrix)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                Console.WriteLine(matrix[row]);
            }
        }
    }
}
