namespace _02.StudentsByFirstAndLastName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByFirstAndLastName
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<Student> students = new List<Student>();


            while (input != "END")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string firstName = inputArgs[0];
                string lastName = inputArgs[1];

                Student student = new Student(firstName, lastName);
                students.Add(student);

                input = Console.ReadLine();
            }

            foreach (var student in students.Where(st => st.FirstName.CompareTo(st.LastName) == -1))
            {
                Console.WriteLine(student.FullName);
            }

        }
    }

    public class Student
    {
        public Student()
        {

        }

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Student(string firstName, string lastName, int group)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Group = group;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Group { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}
