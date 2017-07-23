namespace BashSoft.Models
{
    using System.Collections.Generic;
    using BashSoft.Exceptions;
    using BashSoft.Contracts;

    public class SoftUniCourse : ICourse
    {
        private string name;
        private Dictionary<string, IStudent> studentsByName;

        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        public SoftUniCourse(string courseName)
        {
            this.Name = courseName;
            this.studentsByName = new Dictionary<string, IStudent>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.name = value;
            }
        }

        public IReadOnlyDictionary<string, IStudent> StudentsByName
        {
            get
            {
                return this.studentsByName;
            }
        }

        public void EnrollStudent(IStudent student)
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, this.Name);
            }

            this.studentsByName.Add(student.UserName, student);
        }
    }
}
