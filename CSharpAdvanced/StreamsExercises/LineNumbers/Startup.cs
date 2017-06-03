namespace LineNumbers
{
    using System;
    using System.IO;

    public class Startup
    {
        private const string TestFile = "test.txt";
        private const string ResultFile = "result.txt";

        public static void Main()
        {
            PrepareTestFile();

            AddLineNumbers();

            PrintResultFileContent();
        }

        private static void PrintResultFileContent()
        {
            using (StreamReader reader = new StreamReader(ResultFile))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
        }

        private static void AddLineNumbers()
        {
            using (StreamReader reader = new StreamReader(TestFile))
            {
                using (StreamWriter writer = new StreamWriter(ResultFile))
                {
                    string line = reader.ReadLine();
                    int lineCounter = 1;
                    while (line != null)
                    {
                        writer.WriteLine($"{lineCounter} {line}");
                        lineCounter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }

        static void PrepareTestFile()
        {
            using (StreamWriter writer = new StreamWriter(TestFile))
            {
                for (int i = 1; i <= 100; i++)
                {
                    writer.WriteLine($"TestLineNumber" + i);
                }
            }
        }
    }
}
