namespace SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] inputArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = inputArgs[0];
            int m = inputArgs[1];

            var nElements = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                int currentElement = int.Parse(Console.ReadLine());
                nElements.Add(currentElement);
            }

            var mElements = new HashSet<int>();
            for (int i = 0; i < m; i++)
            {
                int currentElement = int.Parse(Console.ReadLine());
                mElements.Add(currentElement);
            }

            var resultElements = nElements.Intersect(mElements);
            Console.WriteLine(string.Join(" ", resultElements));
        }
    }
}
