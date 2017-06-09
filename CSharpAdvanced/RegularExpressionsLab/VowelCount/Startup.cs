namespace VowelCount
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string pattern = "[AaEeIiOoUuYy]";
            int numberOfVowels = Regex.Matches(Console.ReadLine(), pattern).Count;
            Console.WriteLine($"Vowels: {numberOfVowels}");
        }
    }
}
