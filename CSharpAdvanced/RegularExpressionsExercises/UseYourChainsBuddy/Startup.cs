namespace UseYourChainsBuddy
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        private const string paragraphsPattern = @"<p>(.+?)<\/p>";
        private const string invalidCharactersPattern = @"[^a-z0-9]";

        public static void Main()
        {
            string inputHtml = Console.ReadLine();

            MatchCollection matches = Regex.Matches(inputHtml, paragraphsPattern);
            StringBuilder resultText = new StringBuilder();

            foreach (Match match in matches)
            {
                string paragraphContent = match.Groups[1].Value;

                // Replace invalid characters with spaces
                paragraphContent = Regex.Replace(paragraphContent, invalidCharactersPattern, " ");

                // Convert letters a->n, b->o...
                // n->a, o->b...
                paragraphContent = ConvertLetters(paragraphContent);

                // Replace multiple spaces with only one
                paragraphContent = RemoveRedundantSpaces(paragraphContent);

                resultText.Append(paragraphContent);
            }

            Console.WriteLine(resultText);
        }

        private static string RemoveRedundantSpaces(string paragraphContent)
        {
            return Regex.Replace(paragraphContent, @"\s+", " ");
        }

        private static string ConvertLetters(string paragraphContent)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < paragraphContent.Length; i++)
            {
                int currentChar = paragraphContent[i];

                if (currentChar >= 'a' && currentChar <= 'm')
                {
                    currentChar = currentChar + 13;
                }
                else if (currentChar >= 'm' && currentChar <= 'z')
                {
                    currentChar = currentChar - 13;
                }

                result.Append((char)currentChar);
            }

            return result.ToString();
        }
    }
}
