namespace BashSoft.IO.Commands
{
    using BashSoft.Contracts;
    using BashSoft.Exceptions;

    public class MakeDirectoryCommand : Command
    {
        public MakeDirectoryCommand(
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
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string folderName = this.Data[1];
            this.InputOutputManager.CreateDirectoryInCurrentFolder(folderName);
        }
    }
}
