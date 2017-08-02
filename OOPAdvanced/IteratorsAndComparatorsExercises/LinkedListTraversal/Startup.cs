using System;
using System.Xml;
using System.Xml.XPath;
public class Startup
{
    public static void Main()
    {
        var list = new LinkedList<int>();
        int numberOfInputLines = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfInputLines; i++)
        {
            string[] inputLineArgs = Console.ReadLine().Split();
            string commandName = inputLineArgs[0];
            int value = int.Parse(inputLineArgs[1]);

            if (commandName == "Add")
            {
                list.Add(value);
            }
            else
            {
                list.Remove(value);
            }
        }

        Console.WriteLine(list.Count);
        Console.WriteLine(string.Join(" ", list));
    }
}