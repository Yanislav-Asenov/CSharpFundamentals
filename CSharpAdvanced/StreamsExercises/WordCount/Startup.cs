namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        private const string InputWordsTestFile = "words.txt";
        private const string TestContentFile = "test.txt";
        private const string ResultFile = "result.txt";
        private static Dictionary<string, int> wordsByCount = new Dictionary<string, int>();

        public static void Main()
        {
            CreateWordsTestFile();

            CreateTestContentFile();

            ReadTargetWords();

            CountWordsOccurrences();

            PopulateResultFile();

            PrintResultFile();
        }

        private static void PrintResultFile()
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

        private static void PopulateResultFile()
        {
            using (StreamWriter writer = new StreamWriter(ResultFile))
            {
                foreach (var kvp in wordsByCount.OrderByDescending(kvp => kvp.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }

        private static void CountWordsOccurrences()
        {
            using (StreamReader reader = new StreamReader(TestContentFile))
            {
                string line = reader.ReadLine();
                char[] wordSeparators = new char[] { ' ', '\r', '\t', '.', '?', '!', '-', ',' };

                while (line != null)
                {
                    string[] currentLineWords = line.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.ToLower())
                        .ToArray();

                    foreach (string word in currentLineWords)
                    {
                        string currentWordToLower = word.ToLower();
                        if (wordsByCount.ContainsKey(currentWordToLower))
                        {
                            wordsByCount[currentWordToLower]++;
                        }
                    }

                    line = reader.ReadLine();
                }
            }
        }

        private static void CreateTestContentFile()
        {
            string[] testContent = new string[]
            {
                "-I was quick to judge him, but it wasn't his fault.",
                "-Is this some kind of joke?! Is it?",
                "-Quick, hide here…It is safer."
            };

            using (StreamWriter writer = new StreamWriter(TestContentFile))
            {
                foreach (string line in testContent)
                {
                    writer.WriteLine(line);
                }
            }
        }

        private static void CreateWordsTestFile()
        {
            string[] testWords = new string[]
            {
                "quick",
                "is",
                "fault"
            };

            using (StreamWriter writer = new StreamWriter(InputWordsTestFile))
            {
                foreach (string word in testWords)
                {
                    writer.WriteLine(word);
                }
            }
        }

        private static void ReadTargetWords()
        {
            using (StreamReader reader = new StreamReader(InputWordsTestFile))
            {
                string word = reader.ReadLine().ToLower();
                while (word != null)
                {
                    if (!wordsByCount.ContainsKey(word))
                    {
                        wordsByCount.Add(word, 0);
                    }

                    word = reader.ReadLine();
                }
            }
        }
    }
}
