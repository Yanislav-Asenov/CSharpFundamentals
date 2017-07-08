﻿namespace BashSoft.IO.Commands
{
    using BashSoft.Exceptions;
    using BashSoft.Judge;
    using BashSoft.Repository;

    public class ChangePathRelativelyCommand : Command
    {
        public ChangePathRelativelyCommand(
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

            string relPath = this.Data[1];
            this.InputOutputManager.ChangeCurrentDirectoryRelative(relPath);
        }
    }
}