namespace ParseTags
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            string inputText = Console.ReadLine();

            int startingPoint = 0;
            StringBuilder result = new StringBuilder();
            int indexOfOpeningTag = inputText.IndexOf("<upcase>", startingPoint, StringComparison.Ordinal);
            int indexOfClosingTag = inputText.IndexOf("</upcase>", startingPoint, StringComparison.Ordinal);

            while (indexOfOpeningTag > -1 && indexOfClosingTag > -1)
            {
                result.Append(inputText.Substring(startingPoint, indexOfOpeningTag - startingPoint));

                int payloadLength = indexOfClosingTag - (indexOfOpeningTag + 8);

                result.Append(inputText.Substring(indexOfOpeningTag + 8, payloadLength).ToUpper());

                startingPoint = indexOfClosingTag + 9;

                indexOfOpeningTag = inputText.IndexOf("<upcase>", startingPoint, StringComparison.Ordinal);
                indexOfClosingTag = inputText.IndexOf("</upcase>", startingPoint, StringComparison.Ordinal);
            }

            result.Append(inputText.Substring(startingPoint));
            Console.WriteLine(result);
        }
    }
}
