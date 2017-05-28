namespace AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int numberOfInputPairs = int.Parse(Console.ReadLine());

            SortedDictionary<string, List<double>> studentsWithGrades = new SortedDictionary<string, List<double>>();

            for (int i = 0; i < numberOfInputPairs; i++)
            {
                string studentName = Console.ReadLine();
                double[] grades = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                if (!studentsWithGrades.ContainsKey(studentName))
                {
                    studentsWithGrades.Add(studentName, new List<double>());
                }

                studentsWithGrades[studentName].AddRange(grades);
            }

            foreach (var kvp in studentsWithGrades)
            {
                Console.WriteLine($"{kvp.Key} is graduated with {kvp.Value.Average()}");
            }
        }
    }
}
