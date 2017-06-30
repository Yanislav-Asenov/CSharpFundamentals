namespace _05.FilterStudentsByEmalDomain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterStudentsByEmalDomain
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
                string email = inputArgs[2];

                Student student = new Student(firstName, lastName, email);
                students.Add(student);

                input = Console.ReadLine();
            }

            foreach (var student in students.Where(st => st.Email.Contains("@gmail.com")))
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

        public Student(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Group { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}
