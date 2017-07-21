using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var genericList = new List<double>();
        for (int i = 0; i < n; i++)
        {
            double input = double.Parse(Console.ReadLine());
            genericList.Add(input);
        }
        double comparingElement = double.Parse(Console.ReadLine());
        Console.WriteLine(Compare(genericList, comparingElement));
    }

    public static int Compare<T>(IList<T> list, T element)
      where T : IComparable<T>
    {
        return list.Count(i => i.CompareTo(element) > 0);
    }
}