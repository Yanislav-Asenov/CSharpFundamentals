namespace BashSoft.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BashSoft.IO;
    using BashSoft.StaticData;

    public static class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter == "excellent")
            {
                FilterAndTake(wantedData, x => x >= 5, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(wantedData, x => x < 5 && x >= 3.50, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        {
            int printedStudentsCounter = 0;
            foreach (var userNamePoints in wantedData)
            {
                if (printedStudentsCounter == studentsToTake)
                {
                    break;
                }

                double averageScore = userNamePoints.Value.Average();
                double percentageOfFullfilment = averageScore / 100;
                double mark = percentageOfFullfilment * 4 + 2;

                if (givenFilter(mark))
                {
                    OutputWriter.PrintStudent(userNamePoints);
                    printedStudentsCounter++;
                }
            }
        }

        private static double Average(List<int> scoresOnTask)
        {
            double totalScore = scoresOnTask.Sum();
            double percentageOfAll = totalScore / scoresOnTask.Count / 100.0;
            double mark = percentageOfAll * 4 + 2;

            return mark;
        }
    }
}
