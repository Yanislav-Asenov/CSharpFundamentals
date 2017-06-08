namespace FormattingNumbers
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ' ', '\r', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int a = int.Parse(inputArgs[0]);
            double b = double.Parse(inputArgs[1]);
            double c = double.Parse(inputArgs[2]);

            string result = string.Format("|{0}|{1}|{2}|{3}|",
                Convert.ToString(a, 16).ToUpper().PadRight(10),
                Convert.ToString(a, 2).PadLeft(10, '0').Substring(0, 10),
                b.ToString("0.00").PadLeft(10),
                c.ToString("0.000").PadRight(10));

            Console.WriteLine(result);
        }
    }
}
