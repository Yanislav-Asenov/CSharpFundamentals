namespace BashSoft.Models
{
    using System.Collections.Generic;
    using BashSoft.IO;
    using BashSoft.StaticData;

    public class Course
    {
        private string name;
        public Dictionary<string, Student> studentsByName;

        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        public Course(string courseName)
        {
            this.Name = courseName;
            this.studentsByName = new Dictionary<string, Student>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
            }
        }

        public void EnrollStudent(Student student)
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                OutputWriter.DisplayException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse,
                    student.UserName,
                    this.Name));
                return;
            }

            this.studentsByName.Add(student.UserName, student);
        }
    }
}
