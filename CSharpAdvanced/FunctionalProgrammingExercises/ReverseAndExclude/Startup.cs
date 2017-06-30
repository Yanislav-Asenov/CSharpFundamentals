namespace ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Stack<int> inputNumbers = new Stack<int>(
                Console.ReadLine()
                    .Split()
                    .Select(int.Parse));

            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ", inputNumbers.Where(x => x % n != 0)));
        }
    }
}
