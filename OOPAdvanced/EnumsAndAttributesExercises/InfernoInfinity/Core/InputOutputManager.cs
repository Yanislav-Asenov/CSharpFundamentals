using System;

public class InputOutputManager : IInputOutputManager
{
    public string ReadLine()
    {
        string result = Console.ReadLine();
        return result;
    }

    public void Write(string text)
    {
        Console.Write(text);
    }

    public void WriteLine(string text)
    {
        Console.WriteLine(text);
    }
}