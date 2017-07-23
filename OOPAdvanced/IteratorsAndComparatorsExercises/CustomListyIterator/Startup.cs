using System;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        string[] createCommandArgs = Console.ReadLine().Split();

        var listyIterator = new ListyIterator<string>(createCommandArgs.Skip(1).ToList());

        string commandLine = Console.ReadLine();
        while (commandLine != "END")
        {
            string[] commandArgs = commandLine.Split();
            string commandName = commandArgs[0];

            switch (commandName)
            {
                case "HasNext":
                    Console.WriteLine(listyIterator.HasNext());
                    break;
                case "Move":
                    Console.WriteLine(listyIterator.Move());
                    break;
                case "Print":
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                    }
                    break;
            }

            commandLine = Console.ReadLine();
        }
    }
}