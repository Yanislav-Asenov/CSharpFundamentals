namespace ParseURLs
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string url = Console.ReadLine();

            // Parse protocol
            string protocol = string.Empty;
            int indexOfProtocolSeparator = url.IndexOf("://");
            int indexOfLastProtocolSeparator = url.LastIndexOf("://");

            if (indexOfLastProtocolSeparator == -1 || indexOfProtocolSeparator == -1)
            {
                PrintInvalidUrl();
            }

            if (indexOfProtocolSeparator != indexOfLastProtocolSeparator)
            {
                PrintInvalidUrl();
            }

            protocol = url.Substring(0, url.Length - url.Substring(indexOfProtocolSeparator).Length);

            // Parse server and resources
            url = url.Substring(indexOfProtocolSeparator + 3);
            string server = string.Empty;
            int indexOfResourceSeparator = url.IndexOf("/");
            if (indexOfResourceSeparator == -1)
            {
                PrintInvalidUrl();
            }

            string resources = url.Substring(indexOfResourceSeparator + 1);
            server = url.Substring(0, url.Length - resources.Length - 1);

            Console.WriteLine($"Protocol = {protocol}");
            Console.WriteLine($"Server = {server}");
            Console.WriteLine($"Resources = {resources}");
        }

        private static void PrintInvalidUrl()
        {
            Console.WriteLine("Invalid URL");
            Environment.Exit(0);
        }
    }
}
