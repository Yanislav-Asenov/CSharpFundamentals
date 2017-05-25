namespace MaximumElement
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var numberOfQueries = int.Parse(Console.ReadLine());

            var maxNumbers = new Stack<int>();

            var resultSequence = new Stack<int>();

            for (int i = 0; i < numberOfQueries; i++)
            {
                var queryArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (queryArgs[0] == "1")
                {
                    var numberToPush = int.Parse(queryArgs[1]);
                    resultSequence.Push(numberToPush);

                    if (maxNumbers.Count > 0)
                    {
                        if (numberToPush > maxNumbers.Peek())
                        {
                            maxNumbers.Push(numberToPush);
                        }
                    }
                    else
                    {
                        maxNumbers.Push(numberToPush);
                    }
                }
                else if (queryArgs[0] == "2")
                {
                    if (resultSequence.Count > 0)
                    {
                        var popedNumber = resultSequence.Pop();
                        if (popedNumber == maxNumbers.Peek())
                        {
                            maxNumbers.Pop();
                        }
                    }
                }
                else if (queryArgs[0] == "3")
                {
                    if (maxNumbers.Count > 0)
                    {
                        Console.WriteLine(maxNumbers.Peek());
                    }
                }
            }
        }
    }
}
