namespace BashSoft.IO.Commands
{
    using BashSoft.Exceptions;
    using BashSoft.Judge;
    using BashSoft.Repository;

    public class ShowDataCommand : Command
    {
        public ShowDataCommand(
            string input, 
            string[] data, 
            Tester judge, 
            StudentsRepository studentsRepository, 
            IOManager inputOutputManager) 
            : base(input, data, judge, studentsRepository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string courseName = this.Data[1];
                this.StudentsRepository.GetAllStudentsFromCourse(courseName);
            }
            else if (this.Data.Length == 3)
            {
                string courseName = this.Data[1];
                string username = this.Data[2];
                this.StudentsRepository.GetStudentScoresFromCourse(courseName, username);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
