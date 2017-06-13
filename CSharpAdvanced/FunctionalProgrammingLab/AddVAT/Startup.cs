namespace AddVAT
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(x => Console.WriteLine((double.Parse(x) * 1.2).ToString("F2")));
        }
    }
}
