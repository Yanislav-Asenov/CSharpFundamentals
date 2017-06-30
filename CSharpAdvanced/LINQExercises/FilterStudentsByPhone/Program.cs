namespace _06.FilterStudentsByPhone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterStudentsByPhone
    {
        public static void Main()
        {
            List<Student> students = new List<Student>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string firstName = inputArgs[0];
                string lastName = inputArgs[1];
                string phone = inputArgs[2];

                Student student = new Student(firstName, lastName, phone);
                students.Add(student);

                input = Console.ReadLine();
            }

            foreach (var student in students.Where(st => st.Phone.StartsWith("02") || st.Phone.StartsWith("+3592")))
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

        public Student(string firstName, string lastName, string phone)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Group { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}
