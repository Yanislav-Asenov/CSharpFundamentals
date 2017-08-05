namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;

    [Alias("show")]
    public class ShowDataCommand : Command
    {
        [Inject]
        private IDatabase studentsRepository = null;

        public ShowDataCommand(string input, string[] data) 
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string courseName = this.Data[1];
                this.studentsRepository.GetStudentsByCourse(courseName);
            }
            else if (this.Data.Length == 3)
            {
                string courseName = this.Data[1];
                string username = this.Data[2];
                this.studentsRepository.GetStudentMarkInCourse(courseName, username);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}