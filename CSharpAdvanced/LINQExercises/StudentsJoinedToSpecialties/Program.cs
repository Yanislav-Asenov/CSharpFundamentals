namespace _11.StudentsJoinedToSpecialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsJoinedToSpecialties
    {
        public static void Main()
        {
            List<StudentSpecialty> specialties = new List<StudentSpecialty>();
            List<Student> students = new List<Student>();

            string input = Console.ReadLine();

            while (input != "Students:")
            {
                string[] specialtyArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string speacialtyName = specialtyArgs[0] + " " + specialtyArgs[1];
                string facultyNumber = specialtyArgs[2];

                StudentSpecialty speacialty = new StudentSpecialty(speacialtyName, facultyNumber);
                specialties.Add(speacialty);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "END")
            {
                string[] studentArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string facultyNumber = studentArgs[0];
                string fistName = studentArgs[1];
                string lastName = studentArgs[2];

                Student student = new Student(fistName, lastName, facultyNumber);
                students.Add(student);

                input = Console.ReadLine();
            }

            var result = specialties.Join(
                students,
                ss => ss.FacultyNumber,
                st => st.FacultyNumber,
                (ss, st) => new
                {
                    SpecialtyName = ss.SpeacialtyName,
                    StudentName = st.FullName,
                    FacultyNumber = st.FacultyNumber
                });

            foreach (var item in result.OrderBy(x => x.StudentName))
            {
                Console.WriteLine($"{item.StudentName} {item.FacultyNumber} {item.SpecialtyName}");
            }
        }
    }

    public class StudentSpecialty
    {
        public StudentSpecialty()
        {

        }

        public StudentSpecialty(string speacialtyName, string facultyNumber)
        {
            this.SpeacialtyName = speacialtyName;
            this.FacultyNumber = facultyNumber;
        }

        public string SpeacialtyName { get; set; }

        public string FacultyNumber { get; set; }
    }

    public class Student
    {
        public Student()
        {

        }

        public Student(string firstName, string lastName, string facultyNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacultyNumber = facultyNumber;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";

        public string FacultyNumber { get; set; }
    }
}
