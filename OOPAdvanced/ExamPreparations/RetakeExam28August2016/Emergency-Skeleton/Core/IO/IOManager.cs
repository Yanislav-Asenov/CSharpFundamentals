namespace Emergency_Skeleton.Core.IO
{
    using Emergency_Skeleton.Interfaces.Core.IO;

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
