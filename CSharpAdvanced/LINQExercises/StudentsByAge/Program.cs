namespace _03.StudentsByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByAge
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
                int age = int.Parse(inputArgs[2]);

                Student student = new Student(firstName, lastName, age);
                students.Add(student);

                input = Console.ReadLine();
            }

            foreach (var student in students.Where(st => st.Age >= 18 && st.Age <= 24))
            {
                Console.WriteLine($"{student.FullName} {student.Age}");
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
