namespace MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var inputExpression = Console.ReadLine();
            var expressionIndexTracker = new Stack<int>();

            for (int i = 0; i < inputExpression.Length; i++)
            {
                var currentChar = inputExpression[i];
                if (currentChar == '(')
                {
                    expressionIndexTracker.Push(i);
                }
                else if (currentChar == ')')
                {
                    var startIndex = expressionIndexTracker.Pop();
                    Console.WriteLine(inputExpression.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
