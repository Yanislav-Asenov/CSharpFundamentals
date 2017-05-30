namespace SumOfAllElementsOfMatrix
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string[] inputArgs = Regex.Split(Console.ReadLine(), ", ");
            int rows = int.Parse(inputArgs[0]);
            int cols = int.Parse(inputArgs[1]);
            long sum = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Regex.Split(Console.ReadLine(), ", ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    sum += currentRow[col];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
