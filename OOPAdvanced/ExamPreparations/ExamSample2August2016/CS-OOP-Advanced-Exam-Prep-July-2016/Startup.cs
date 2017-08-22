namespace CS_OOP_Advanced_Exam_Prep_July_2016
{
    using CS_OOP_Advanced_Exam_Prep_July_2016.Core;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Core.IO;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Interfaces.Core;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Interfaces.IO;

    public class Startup
    {
        static void Main(string[] args)
        {
            IInputReader reader = new ConsoleReader();
            IOutputWriter writer = new ConsoleWriter();
            IInputOutputManager inputOutputManager = new IOManager(reader, writer);

            IParser parser = new AttributeParser();

            IEngine engine = new Engine(inputOutputManager, parser);
            engine.Run();
        }
    }
}
