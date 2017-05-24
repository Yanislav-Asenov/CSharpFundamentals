namespace SimpleCalculator
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var inputExpression = Console.ReadLine().Split(' ');

            var expressionTracker = new Stack<string>();
            
            foreach (var item in inputExpression)
            {
                var currentNum = 0.0;
                if (double.TryParse(item, out currentNum))
                {
                    if (expressionTracker.Count == 0)
                    {
                        expressionTracker.Push(item);
                    }
                    else
                    {
                        var operand = expressionTracker.Pop();
                        var numberInTracker = double.Parse(expressionTracker.Pop());
                        string result = string.Empty;

                        if (operand == "+")
                        {
                            result = numberInTracker + currentNum + "";
                        }
                        else if (operand == "-")
                        {
                            result = numberInTracker - currentNum + "";
                        }

                        expressionTracker.Push(result);
                    }
                }
                else if (item == "+" || item == "-")
                {
                    expressionTracker.Push(item);
                }
            }

            Console.WriteLine(expressionTracker.Pop());
        }
    }
}
