using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        IList<string> inputItems = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        Lake<string> lake = new Lake<string>(inputItems);

        Console.WriteLine(string.Join(", ", lake));
    }
}