namespace BashSoft.IO.Commands
{
    using BashSoft.Exceptions;
    using BashSoft.Judge;
    using BashSoft.Repository;
    using BashSoft.StaticData;

    public class OrderAndTakeCommand : Command
    {
        public OrderAndTakeCommand(
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
            if (this.Data.Length != 5)
            {
                throw new InvalidCommandException(this.Input);
            }

            string courseName = this.Data[1];
            string order = this.Data[2].ToLower();
            string orderCommand = this.Data[3].ToLower();
            string takeQuantity = this.Data[4].ToLower();

            this.TryParseParameters(orderCommand, takeQuantity, courseName, order);

        }

        private void TryParseParameters(string takeCommand, string takeQuantity, string courseName, string order)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.StudentsRepository.OrderAndTake(courseName, order);
                }
                else
                {
                    if (int.TryParse(takeQuantity, out int studentsToTake))
                    {
                        this.StudentsRepository.OrderAndTake(courseName, order, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }
    }
}
