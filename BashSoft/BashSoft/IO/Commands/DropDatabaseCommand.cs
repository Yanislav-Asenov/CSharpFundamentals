namespace BashSoft.IO.Commands
{
    using BashSoft.Contracts;
    using BashSoft.Exceptions;

    public class DropDatabaseCommand : Command
    {
        public DropDatabaseCommand(
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
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.StudentsRepository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}
