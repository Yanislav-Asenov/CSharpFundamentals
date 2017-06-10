namespace ReplaceTag
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            var text = string.Empty;

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end") break;

                text += "\n" + input;
            }

            var regex = new Regex("<a\\s*href\\s*=\\s*\"(.*?)\">(.*)<\\/a>");
            string result = regex.Replace(text, (m) => $"[URL href=\"{m.Groups[1]}\"]{m.Groups[2].Value}[/URL]", 1);

            Console.WriteLine(result);
        }
    }
}
