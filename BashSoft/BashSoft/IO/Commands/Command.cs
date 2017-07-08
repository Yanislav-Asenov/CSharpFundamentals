namespace BashSoft.IO.Commands
{
    using System;
    using BashSoft.Exceptions;
    using BashSoft.Judge;
    using BashSoft.Repository;

    public abstract class Command
    {
        private string input;
        private string[] data;
        private Tester judge;
        private StudentsRepository studentsRepository;
        private IOManager inputOutputManager;

        public Command(
            string input, 
            string[] data, 
            Tester judge, 
            StudentsRepository studentsRepository,
            IOManager inputOutputManager)
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

        protected Tester Judge => this.judge;
        protected StudentsRepository StudentsRepository => this.studentsRepository;
        protected IOManager InputOutputManager => this.inputOutputManager;

        public abstract void Execute();
    }
}
