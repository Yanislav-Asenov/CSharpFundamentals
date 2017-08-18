using System;
using System.Collections.Generic;
using System.Linq;

public class Engine : IRunnable
{
    private readonly IInputOutputManager inputOutputManager;
    private IManager heroManager;

    public Engine(IInputOutputManager inputOutputManager, IManager heroManager)
    {
        this.inputOutputManager = inputOutputManager;
        this.heroManager = heroManager;
    }

    public void Run()
    {
        while (true)
        {
            string inputLine = this.inputOutputManager.ReadLine();
            IList<string> arguments = this.ParseInput(inputLine);
            this.inputOutputManager.AppendLine(this.ProcessInput(arguments));

            if (inputLine == "Quit")
            {
                break;
            }
        }

        this.inputOutputManager.Write();
    }

    private IList<string> ParseInput(string input)
    {
        return input.Split(' ').ToList();
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