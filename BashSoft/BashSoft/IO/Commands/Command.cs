namespace BashSoft.IO.Commands
{
    using System;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;

    public abstract class Command : IExecutable
    {
        private string input;
        private string[] data;
        private IContentComparer judge;
        private IDatabase studentsRepository;
        private IDirectoryMananger inputOutputManager;

        public Command(
            string input, 
            string[] data,
            IContentComparer judge,
            IDatabase studentsRepository,
            IDirectoryMananger inputOutputManager)
        {
            this.Input = input;
            this.Data = data;
            this.judge = judge;
            this.studentsRepository = studentsRepository;
            this.inputOutputManager = inputOutputManager;
        }

        public string Input
        {
            get => this.input;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        public string[] Data
        {
            get => this.data;
            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        protected IContentComparer Judge => this.judge;

        protected IDatabase StudentsRepository => this.studentsRepository;

        protected IDirectoryMananger InputOutputManager => this.inputOutputManager;

        public abstract void Execute();
    }
}
