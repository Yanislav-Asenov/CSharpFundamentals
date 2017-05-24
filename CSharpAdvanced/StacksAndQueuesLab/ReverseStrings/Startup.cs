namespace ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            var charactersStack = new Stack<char>();

            foreach (var ch in input)
            {
                charactersStack.Push(ch);
            }

            Console.WriteLine(string.Join("", charactersStack));
        }
    }
}