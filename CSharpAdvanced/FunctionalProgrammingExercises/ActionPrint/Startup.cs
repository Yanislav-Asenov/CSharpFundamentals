namespace ActionPrint
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Action<string> printNames = names => Console.WriteLine(string.Join("\n", names.Split()));
            printNames(Console.ReadLine());
        }
    }
}
