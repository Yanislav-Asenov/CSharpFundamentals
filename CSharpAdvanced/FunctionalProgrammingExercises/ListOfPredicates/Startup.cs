namespace ListOfPredicates
{
    using System;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            int endOfRange = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).Distinct().ToArray();

            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= endOfRange; i++)
            {
                bool isDivisibleByAll = true;
                for (int j = 0; j < dividers.Length; j++)
                {
                    if (i % dividers[j] != 0)
                    {
                        isDivisibleByAll = false;
                        break;
                    }
                }

                if (isDivisibleByAll)
                {
                    result.Append(i + " ");
                }
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
