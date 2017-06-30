namespace _01.StudentsByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByGroup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<Student> students = new List<Student>();

            while (input != "END")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string studentFirstName = inputArgs[0];
                string studentLastName = inputArgs[1];
                int studentGroup = int.Parse(inputArgs[2]);

                Student student = new Student(studentFirstName, studentLastName, studentGroup);
                students.Add(student);

                input = Console.ReadLine();
            }

            foreach (var student in students.Where(st => st.Group == 2).OrderBy(st => st.FirstName))
            {
                Console.WriteLine(student.FullName);
            }
        }
    }

    public class Student
    {
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
