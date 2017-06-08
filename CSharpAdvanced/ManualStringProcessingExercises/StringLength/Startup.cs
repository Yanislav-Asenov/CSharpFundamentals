namespace StringLength
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string inputString = Console.ReadLine();
            Console.WriteLine(inputString.Substring(0, Math.Min(20, inputString.Length)).PadRight(20, '*'));
        }
    }
}
