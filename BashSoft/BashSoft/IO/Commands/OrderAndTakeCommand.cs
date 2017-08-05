namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;
    using BashSoft.StaticData;

    [Alias("order")]
    public class OrderAndTakeCommand : Command
    {
        [Inject]
        private IDatabase studentsRepository = null;

        public OrderAndTakeCommand(string input, string[] data) 
            : base(input, data)
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
                    this.studentsRepository.OrderAndTake(courseName, order);
                }
                else
                {
                    int studentsToTake;
                    if (int.TryParse(takeQuantity, out studentsToTake))
                    {
                        this.studentsRepository.OrderAndTake(courseName, order, studentsToTake);
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