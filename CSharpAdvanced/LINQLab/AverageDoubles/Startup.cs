namespace AverageDoubles
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine(Console.ReadLine().Split().Select(double.Parse).Average().ToString("F2"));
        }
    }
}
