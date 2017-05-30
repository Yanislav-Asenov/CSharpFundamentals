namespace MatrixOfPalindromes
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] inputArgs = Console.ReadLine().Split(' ');
            int rows = int.Parse(inputArgs[0]);
            int cols = int.Parse(inputArgs[1]);

            char startChar = 'a';

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    char leftRightChar = (char) startChar;
                    char middleChar = (char) (startChar + col);
                    Console.Write($"{leftRightChar}{middleChar}{leftRightChar} ");
                }

                startChar++;
                Console.WriteLine();
            }
        }
    }
}
