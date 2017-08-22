namespace CS_OOP_Advanced_Exam_Prep_July_2016.Core.IO
{
    using CS_OOP_Advanced_Exam_Prep_July_2016.Interfaces.IO;

    public class IOManager : IInputOutputManager
    {
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        public IOManager(IInputReader reader, IOutputWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public string ReadLine()
        {
            return this.reader.ReadLine();
        }

        public void WriteLine(string output)
        {
            this.writer.WriteLine(output);
        }
    }
}
