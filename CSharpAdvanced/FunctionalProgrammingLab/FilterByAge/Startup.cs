namespace FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            var ageByNames = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputLineArgs = Regex.Split(Console.ReadLine(), ", ");
                string name = inputLineArgs[0];
                int age = int.Parse(inputLineArgs[1]);

                ageByNames[name] = age;
            }

            string condigion = Console.ReadLine();
            int ageForCondition = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            PrintResult(ageByNames, condigion, ageForCondition, format);
        }

        private static void PrintResult(Dictionary<string, int> ageByNames, string condigion, int ageForCondition, string format)
        {
            var result = ageByNames;
            if (condigion == "younger")
            {
                result = result.Where(x => x.Value <= ageForCondition).ToDictionary(x => x.Key, x => x.Value);
            }
            else if (condigion == "older")
            {
                result = result.Where(x => x.Value >= ageForCondition).ToDictionary(x => x.Key, x => x.Value);
            }

            if (format == "name age")
            {
                foreach (var kvp in result)
                {
                    Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
            else if (format == "name")
            {
                foreach (var kvp in result)
                {
                    Console.WriteLine($"{kvp.Key}");
                }
            }
            else if (format == "age")
            {
                foreach (var kvp in result)
                {
                    Console.WriteLine($"{kvp.Value}");
                }
            }
        }
    }
}
