using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    private readonly StringBuilder content;

    public ConsoleWriter()
        : this(new StringBuilder())
    {

    }

    public ConsoleWriter(StringBuilder content)
    {
        this.content = content;
    }

    public void AppendLine(string line)
    {
        this.content.AppendLine(line);
    }

    public void Write()
    {
        Console.Write(this.content.ToString());
    }
}