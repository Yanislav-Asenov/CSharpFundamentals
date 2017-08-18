public class InputOutputManager : IInputOutputManager
{
    private readonly IWriter writer;
    private readonly IReader reader;

    public InputOutputManager(IWriter writer, IReader reader)
    {
        this.writer = writer;
        this.reader = reader;
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