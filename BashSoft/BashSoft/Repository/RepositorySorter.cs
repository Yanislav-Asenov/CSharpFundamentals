namespace BashSoft.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using BashSoft.IO;
    using BashSoft.StaticData;
    using BashSoft.Contracts;

    public class RepositorySorter : IDataSorter
    {
        public void OrderAndTake(Dictionary<string, double> studentsWithMarks, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                PrintStudents(studentsWithMarks.OrderBy(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison == "descending")
            {
                PrintStudents(studentsWithMarks.OrderByDescending(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (KeyValuePair<string, double> studentWithMark in studentsSorted)
            {
                OutputWriter.PrintStudent(studentWithMark);
            }
        }
    }
}
