namespace LegoBlocks
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[][] firstMatrix = new int[n][];
            for (int row = 0; row < n; row++)
            {
                firstMatrix[row] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            int[][] secondMatrix = new int[n][];
            for (int row = 0; row < n; row++)
            {
                secondMatrix[row] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            // Reverse second matrix rows.
            for (int row = 0; row < n; row++)
            {
                secondMatrix[row] = secondMatrix[row].Reverse().ToArray();
            }

            // Combine matrices.
            int[][] combinedMatrice = new int[n][];
            for (int row = 0; row < n; row++)
            {
                combinedMatrice[row] = firstMatrix[row].Concat(secondMatrix[row]).ToArray();
            }

            int firstRowLength = combinedMatrice[0].Length;
            bool areFit = true;
            int totalNumberOfCells = 0;
            for (int row = 0; row < n; row++)
            {
                if (combinedMatrice[row].Length != firstRowLength)
                {
                    areFit = false;
                }

                totalNumberOfCells += combinedMatrice[row].Length;
            }

            if (areFit)
            {
                PrintMatrix(combinedMatrice);
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {totalNumberOfCells}");
            }
        }

        private static void PrintMatrix(int[][] combinedMatrice)
        {
            for (int row = 0; row < combinedMatrice.Length; row++)
            {
                Console.WriteLine($"[{string.Join(", ", combinedMatrice[row])}]");
            }
        }
    }
}
