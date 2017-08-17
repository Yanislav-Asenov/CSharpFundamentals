namespace RecyclingStation.BusinessLogic.IO
{
    using RecyclingStation.BusinessLogic.Interfaces.IO;

    public class InputOutputManager : IInputOutputManager
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public InputOutputManager(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void AppendLine(string text)
        {
            this.writer.AppendLine(text);
        }

        public void Write()
        {
            this.writer.Write();
        }

        public string ReadLine()
        {
            return this.reader.ReadLine();
        }
    }
}
