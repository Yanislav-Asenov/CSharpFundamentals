namespace CountUppercaseWords
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => char.IsUpper(x[0]))
                .ToList()
                .ForEach(x => Console.WriteLine(x));

        }
    }
}
