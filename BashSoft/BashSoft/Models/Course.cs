namespace BashSoft.Models
{
    using System;
    using System.Collections.Generic;
    using BashSoft.IO;
    using BashSoft.StaticData;

    public class Course
    {
        private string name;
        private Dictionary<string, Student> studentsByName;

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.name),
                        ExceptionMessages.NullOrEmptyValue);
                }

                this.name = value;
            }
        }

        public IReadOnlyDictionary<string, Student> StudentsByName
        {
            get
            {
                return this.studentsByName;
            }
        }

        public void EnrollStudent(Student student)
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse,
                    student.UserName,
                    this.Name));
            }

            this.studentsByName.Add(student.UserName, student);
        }
    }
}
