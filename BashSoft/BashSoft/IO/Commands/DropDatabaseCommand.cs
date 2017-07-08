namespace BashSoft.IO.Commands
{
    using BashSoft.Exceptions;
    using BashSoft.Judge;
    using BashSoft.Repository;

    public class DropDatabaseCommand : Command
    {
        public DropDatabaseCommand(
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
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.StudentsRepository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}
