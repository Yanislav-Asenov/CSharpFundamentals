namespace _10.GroupByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GroupByGroup
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
                int group = int.Parse(inputArgs[2]);

                Student student = new Student(firstName, lastName, group);
                students.Add(student);

                input = Console.ReadLine();
            }

            var groupsWithTheirStudents = students.GroupBy(st => st.Group, st => st.FullName);

            foreach (var groupWithTheirStudents in groupsWithTheirStudents.OrderBy(gr => gr.Key))
            {
                Console.WriteLine("{0} - {1}",
                    groupWithTheirStudents.Key,
                    string.Join(", ", groupWithTheirStudents));
            }
        }
    }

    public class Student
    {
        public Student()
        {

        }

        public Student(string firstName, string lastName, int group)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Group = group;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";

        public int Group { get; set; }
    }
}
