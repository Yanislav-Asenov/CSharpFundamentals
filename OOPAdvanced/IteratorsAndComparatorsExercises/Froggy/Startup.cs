using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        IList<int> inputItems = Console.ReadLine()
            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        Lake lake = new Lake(inputItems);

        Console.WriteLine(string.Join(", ", lake));
    }
}