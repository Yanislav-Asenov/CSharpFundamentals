namespace Palindromes
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            char[] delimiters = new char[] { ' ', ',', '.', '?', '!' };
            string[] input = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            SortedSet<string> resultPalindromes = new SortedSet<string>();

            foreach (var word in input)
            {
                if (IsPalindrome(word))
                {
                    resultPalindromes.Add(word);
                }
            }

            Console.WriteLine($"[{string.Join(", ", resultPalindromes)}]");
        }

        private static bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
