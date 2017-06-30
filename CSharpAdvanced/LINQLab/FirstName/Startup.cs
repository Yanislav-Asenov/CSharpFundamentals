namespace FirstName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string[] inputNames = Console.ReadLine().Split().Select(x => x).ToArray();
            HashSet<string> inputLetters = new HashSet<string>(Console.ReadLine().Split().Select(x => x).ToArray());

            string resultNames = inputNames
                .Where(name => inputLetters.Any(letter => name.ToLower().StartsWith(letter.ToLower())))
                .OrderBy(x => x)
                .FirstOrDefault();

            if (resultNames != null)
            {
                Console.WriteLine(string.Join(" ", resultNames));
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}
