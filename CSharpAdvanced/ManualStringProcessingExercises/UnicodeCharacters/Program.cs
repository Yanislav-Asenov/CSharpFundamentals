namespace UnicodeCharacters
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string resultString = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                resultString += GetEscapeSequence(input[i]);
            }

            Console.WriteLine(resultString.ToLower());
        }

        private static string GetEscapeSequence(char c)
        {
            return "\\u" + ((int)c).ToString("X4");
        }
    }
}
