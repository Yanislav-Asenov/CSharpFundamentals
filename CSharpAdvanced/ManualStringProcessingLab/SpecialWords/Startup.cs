namespace SpecialWords
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            char[] wordSeparators = new char[] { '(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' ' };
            string[] specialWords = Console.ReadLine().Split(wordSeparators);
            string[] textWords = Console.ReadLine().Split(wordSeparators);

            foreach (var word in specialWords)
            {
                int numberOfOccurrences = 0;
                foreach (var w in textWords)
                {
                    if (word == w)
                    {
                        numberOfOccurrences++;
                    }
                }

                Console.WriteLine($"{word} - {numberOfOccurrences}");
            }
        }
    }
}
