namespace BashSoft.IO
{
    using System;
    using BashSoft.Exceptions;
    using BashSoft.IO.Commands;
    using BashSoft.Judge;
    using BashSoft.Repository;

    public class CommandInterpreter
    {
        private Tester judge;
        private StudentsRepository studentsRepository;
        private IOManager inputOutputManager;

        public CommandInterpreter(Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            this.judge = judge;
            this.studentsRepository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];

            try
            {
                Command command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }
        }

        private Command ParseCommand(string input, string command, string[] data)
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
                default:
                    throw new InvalidCommandException(input);
            }
        }
    }
}
