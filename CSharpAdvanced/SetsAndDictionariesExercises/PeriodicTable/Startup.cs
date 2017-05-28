namespace PeriodicTable
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int numberOfElements = int.Parse(Console.ReadLine());

            var resultElements = new SortedSet<string>();

            for (int i = 0; i < numberOfElements; i++)
            {
                var currentElements = Console.ReadLine().Split(' ');

                foreach (var element in currentElements)
                {
                    if (!resultElements.Contains(element))
                    {
                        resultElements.Add(element);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", resultElements));
        }
    }
}
