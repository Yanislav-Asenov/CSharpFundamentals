using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    public class Startup
    {
        public static void Main()
        {
            SortedDictionary<double, int> occurrences = new SortedDictionary<double, int>();

            Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList()
                .ForEach(x =>
                {
                    if (!occurrences.ContainsKey(x))
                    {
                        occurrences.Add(x, 0);
                    }

                    occurrences[x]++;
                });

            foreach (var kvp in occurrences)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
