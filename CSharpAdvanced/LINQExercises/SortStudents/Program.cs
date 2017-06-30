namespace _04.SortStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortStudents
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

            foreach (var student in students.OrderBy(st => st.LastName).ThenByDescending(st => st.FirstName))
            {
                Console.WriteLine($"{student.FullName}");
            }
        }
    }

    public class Student
    {
        public Student()
        {

        }

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Group { get; set; }

        public int Age { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}
