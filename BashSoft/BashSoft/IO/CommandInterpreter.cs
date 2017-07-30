namespace BashSoft.IO
{
    using System;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;
    using BashSoft.IO.Commands;

    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase studentsRepository;
        private IDirectoryMananger inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryMananger inputOutputManager)
        {
            this.judge = judge;
            this.studentsRepository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpretCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];

            try
            {
                IExecutable command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }
        }

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {
                case "open":
                    return new OpenFileCommand(input, data, this.judge, this.studentsRepository, this.inputOutputManager);
                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.studentsRepository, this.inputOutputManager);
                case "ls":
                    return new TraverseFolderCommand(input, data, this.judge, this.studentsRepository, this.inputOutputManager);
                case "cmp":
                    return new CompareFilesCommand(input, data, this.judge, this.studentsRepository, this.inputOutputManager);
                case "cdRel":
                    return new ChangePathRelativelyCommand(input, data, this.judge, this.studentsRepository, this.inputOutputManager);
                case "cdAbs":
                    return new ChangePathAbsoluteCommand(input, data, this.judge, this.studentsRepository, this.inputOutputManager);
                case "readDb":
                    return new ReadDatabaseFromFileCommand(input, data, this.judge, this.studentsRepository, this.inputOutputManager);
                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.studentsRepository, this.inputOutputManager);
                case "filter":
                    return new FilterAndTakeCommand(input, data, this.judge, this.studentsRepository, this.inputOutputManager);
                case "order":
                    return new OrderAndTakeCommand(input, data, this.judge, this.studentsRepository, this.inputOutputManager);
                case "dropdb":
                    return new DropDatabaseCommand(input, data, this.judge, this.studentsRepository, this.inputOutputManager);
                case "show":
                    return new ShowDataCommand(input, data, this.judge, this.studentsRepository, this.inputOutputManager);
                case "display":
                    return new DisplayCommand(input, data, this.judge, this.studentsRepository, this.inputOutputManager);
                default:
                    throw new InvalidCommandException(input);
            }
        }
    }
}
