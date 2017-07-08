namespace BashSoft.IO.Commands
{
    using System.Diagnostics;
    using BashSoft.Exceptions;
    using BashSoft.Judge;
    using BashSoft.Repository;
    using BashSoft.StaticData;

    public class OpenFileCommand : Command
    {
        public OpenFileCommand(
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
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string fileName = this.Data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }
    }
}
