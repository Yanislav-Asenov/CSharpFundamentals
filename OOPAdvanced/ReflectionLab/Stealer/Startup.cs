using System;

public class Startup
{
    public static void Main()
    {
        Spy spy = new Spy();

        Console.WriteLine(spy.AnalyzeAcessModifiers("Hacker"));
    }
}