using System;
using System.Collections.Generic;
using System.Linq;

public class Engine : IRunnable
{
    private readonly IOutputWriter reader;
    private readonly IInputReader writer;
    private IManager heroManager;

    public Engine(IOutputWriter reader, IInputReader writer, IManager heroManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroManager = heroManager;
    }

    public void Run()
    {
        while (true)
        {
            string inputLine = this.reader.ReadLine();
            IList<string> arguments = this.ParseInput(inputLine);
            this.writer.AppendLine(this.ProcessInput(arguments));

            if (inputLine == "Quit")
            {
                break;
            }
        }

        this.writer.Write();
    }

    private IList<string> ParseInput(string input)
    {
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private string ProcessInput(IList<string> arguments)
    {
        string command = arguments[0];
        arguments.RemoveAt(0);

        Type commandType = Type.GetType(command + "Command");
        IExecutable cmd = Activator.CreateInstance(commandType, new object[] { arguments, this.heroManager }) as IExecutable;

        return cmd.Execute();
    }
}