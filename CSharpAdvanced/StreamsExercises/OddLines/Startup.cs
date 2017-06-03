namespace OddLines
{
    using System;
    using System.IO;

    public class Startup
    {
        private const string TestFile = "test.txt";

        public static void Main()
        {
            PrepareTestFile();
            PrintOddLines();
        }

        private static void PrintOddLines()
        {
            using (StreamReader reader = new StreamReader(TestFile))
            {
                string line = reader.ReadLine();
                int lineCounter = 0;
                while (line != null)
                {

                    if (lineCounter % 2 == 0)
                    {
                        Console.WriteLine(line);
                    }

                    lineCounter++;
                    line = reader.ReadLine();
                }
            }
        }

        static void PrepareTestFile()
        {
            using (StreamWriter writer = new StreamWriter(TestFile))
            {
                for (int i = 0; i < 99; i++)
                {
                    if (i % 2 == 0)
                    {
                        writer.WriteLine($"{i} - even");
                    }
                    else
                    {
                        writer.WriteLine($"{i} - odd");
                    }
                }
            }
        }
    }
}
