namespace MelrahShake
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string inputString = Console.ReadLine();
            string pattern = Console.ReadLine();


            while (true)
            {
                int indexOfFirstMatch = inputString.IndexOf(pattern);
                int indexOfSecondMatch = inputString.LastIndexOf(pattern);
                if (indexOfFirstMatch != indexOfSecondMatch && indexOfFirstMatch != -1 && indexOfSecondMatch != -1 && pattern.Length > 0)
                {
                    Console.WriteLine("Shaked it.");

                    inputString = inputString.Remove(indexOfFirstMatch, pattern.Length);
                    indexOfSecondMatch = inputString.LastIndexOf(pattern);
                    inputString = inputString.Remove(indexOfSecondMatch, pattern.Length);

                    pattern = pattern.Remove(pattern.Length / 2, 1);

                }
                else
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(inputString);
                    return;
                }
            }
        }
    }
}
