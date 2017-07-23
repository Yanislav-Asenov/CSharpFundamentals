namespace BashSoft.IO.Commands
{
    using BashSoft.Contracts;
    using BashSoft.Exceptions;

    public class ShowDataCommand : Command
    {
        public ShowDataCommand(
            string input, 
            string[] data,
            IContentComparer judge,
            IDatabase studentsRepository,
            IDirectoryMananger inputOutputManager) 
            : base(input, data, judge, studentsRepository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string courseName = this.Data[1];
                this.StudentsRepository.GetStudentsByCourse(courseName);
            }
            else if (this.Data.Length == 3)
            {
                string courseName = this.Data[1];
                string username = this.Data[2];
                this.StudentsRepository.GetStudentMarkInCourse(courseName, username);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
