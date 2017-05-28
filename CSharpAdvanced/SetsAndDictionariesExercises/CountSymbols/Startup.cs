namespace CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string inputText = Console.ReadLine();

            var charactersDict = new SortedDictionary<char, int>();

            foreach (var ch in inputText)
            {
                if (!charactersDict.ContainsKey(ch))
                {
                    charactersDict[ch] = 0;
                }

                charactersDict[ch]++;
            }

            foreach (var kvp in charactersDict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
