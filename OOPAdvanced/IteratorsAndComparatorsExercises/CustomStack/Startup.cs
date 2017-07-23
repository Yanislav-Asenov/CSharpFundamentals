using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Startup
{
    private static ICustomStack<string> customStack = new CustomStack<string>();

    public static void Main()
    {
        string inputLine = Console.ReadLine();

        while (inputLine != "END")
        {
            string[] commandArgs = inputLine.Split(new [] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandArgs[0];

            switch (commandName)
            {
                case "Push":
                    ExecutePushCommand(commandArgs.Skip(1).ToList());
                    break;
                case "Pop":
                    ExecutePopCommand();
                    break;
            }

            inputLine = Console.ReadLine();
        }

        for (int i = 0; i < 2; i++)
        {
            PrintCollection();
        }
    }

    private static void PrintCollection()
    {
        StringBuilder result = new StringBuilder();
        foreach (var item in customStack)
        {
            result.Append(item).AppendLine();
        }

        string resultAsString = result.ToString().Trim();

        if (string.IsNullOrEmpty(resultAsString))
        {
            return;
        }

        Console.WriteLine(resultAsString);
    }

    private static void ExecutePopCommand()
    {
        try
        {
            customStack.Pop();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void ExecutePushCommand(List<string> items)
    {
        foreach (var item in items)
        {
            customStack.Push(item);
        }
    }
}