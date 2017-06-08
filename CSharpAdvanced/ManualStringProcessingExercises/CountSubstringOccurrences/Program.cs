namespace CountSubstringOccurrences
{
    using System;

    public class Statup
    {
        public static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string searchText = Console.ReadLine().ToLower();

            int occurrences = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int substringLength = searchText.Length;
                if (i + substringLength >= text.Length)
                {
                    substringLength = searchText.Length - ((i + searchText.Length) - text.Length);
                }

                string currentText = text.Substring(i, substringLength);

                if (currentText.Contains(searchText))
                {
                    occurrences++;
                }
            }

            Console.WriteLine(occurrences);
        }
    }
}
