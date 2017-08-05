namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;

    [Alias("readdb")]
    public class ReadDatabaseFromFileCommand : Command
    {
        [Inject]
        private IDatabase studentsRepository = null;

        public ReadDatabaseFromFileCommand(string input, string[] data) 
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string fileName = this.Data[1];
            this.studentsRepository.LoadData(fileName);
        }
    }
}
