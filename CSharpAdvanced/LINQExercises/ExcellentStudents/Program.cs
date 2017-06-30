namespace _07.ExcellentStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExcellentStudents
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
                var marks = new List<int>
                {
                    int.Parse(inputArgs[2]),
                    int.Parse(inputArgs[3]),
                    int.Parse(inputArgs[4]),
                    int.Parse(inputArgs[5])
                };

                Student student = new Student(firstName, lastName, marks);
                students.Add(student);

                input = Console.ReadLine();
            }

            foreach (var student in students.Where(st => st.Marks.Contains(6)))
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

        public Student(string firstName, string lastName, List<int> marks)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Marks = marks;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Group { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public List<int> Marks { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}
