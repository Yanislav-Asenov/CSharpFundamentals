using System;

public class Startup
{
    public static void Main()
    {
        string[] tuple1Args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Tuple<string, string> tuple1 = new Tuple<string, string>(tuple1Args[0] + " " + tuple1Args[1], tuple1Args[2]);

        string[] tuple2Args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Tuple<string, int> tuple2;

        if (tuple2Args.Length < 2)
        {
            tuple2 = new Tuple<string, int>(tuple2Args[0], 0);
        }
        else
        {
            tuple2 = new Tuple<string, int>(tuple2Args[0], int.Parse(tuple2Args[1]));
        }

        string[] tuple3Args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Tuple<string, double> tuple3 = new Tuple<string, double>(tuple3Args[0], double.Parse(tuple3Args[1]));

        Console.WriteLine(tuple1);
        Console.WriteLine(tuple2);
        Console.WriteLine(tuple3);
    }
}