using System;

public class Startup
{
    public static void Main()
    {
        string[] tuple1Args = Console.ReadLine().Split();
        Threeuple<string, string, string> tuple1 = new Threeuple<string, string, string>(tuple1Args[0] + " " + tuple1Args[1], tuple1Args[2], tuple1Args[3]);

        string[] tuple2Args = Console.ReadLine().Split();
        Threeuple<string, int, bool> tuple2 = new Threeuple<string, int, bool>(tuple2Args[0], int.Parse(tuple2Args[1]), tuple2Args[2] == "drunk" ? true: false);

        string[] tuple3Args = Console.ReadLine().Split();
        Threeuple<string, double, string> tuple3 = new Threeuple<string, double, string>(tuple3Args[0], double.Parse(tuple3Args[1]), tuple3Args[2]);

        Console.WriteLine(tuple1);
        Console.WriteLine(tuple2);
        Console.WriteLine(tuple3);
    }
}