namespace CS_OOP_Advanced_Exam_Prep_July_2016.Core
{
    using CS_OOP_Advanced_Exam_Prep_July_2016.Interfaces.Core;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Interfaces.IO;

    public class Engine : IEngine
    {
        private const string TerminateProgramCommand = "ILIENCI";

        private readonly IInputOutputManager inputOutputManager;
        private readonly IParser parser;

        public Engine(IInputOutputManager inputOutputManager, IParser parser)
        {
            this.inputOutputManager = inputOutputManager;
            this.parser = parser;
        }

        public void Run()
        {
            this.parser.Parse();

            string inputLine = this.inputOutputManager.ReadLine();
            while (inputLine != TerminateProgramCommand)
            {
                inputLine = this.inputOutputManager.ReadLine();
            }
        }
    }
}
