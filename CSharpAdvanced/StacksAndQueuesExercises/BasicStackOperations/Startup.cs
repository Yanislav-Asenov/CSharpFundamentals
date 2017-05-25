namespace BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            // Get the first line of input args.
            var arguments = Console.ReadLine().
                Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var numberOfElementsToPush = arguments[0];
            var numberOfElementsToPop = arguments[1];
            var numberToCheck = arguments[2];

            // Get the second line of input args (input numbers).
            var sourceElements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var resultStack = new Stack<int>();

            PushElements(numberOfElementsToPush, sourceElements, resultStack);

            PopElements(numberOfElementsToPop, resultStack);

            // If stack is empty print 0.
            if (resultStack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (resultStack.Contains(numberToCheck))
            {
                // If stack contains target number print "true".
                Console.WriteLine("true");
            }
            else
            {
                // If all of the above fail print the smallest number in the stack.
                PrintSmallestElementInSequence(resultStack);
            }
        }

        private static void PrintSmallestElementInSequence(Stack<int> resultStack)
        {
            var minNumber = int.MaxValue;

            while (resultStack.Count > 0)
            {
                var currentNum = resultStack.Pop();

                if (currentNum < minNumber)
                {
                    minNumber = currentNum;
                }
            }

            Console.WriteLine(minNumber);
        }

        private static void PopElements(int numberOfElementsToPop, Stack<int> resultStack)
        {
            int numberOfElementsPoped = 0;

            while (resultStack.Count > 0 && numberOfElementsPoped != numberOfElementsToPop)
            {
                resultStack.Pop();
                numberOfElementsPoped++;
            }
        }

        private static void PushElements(int numberOfElementsToPush, IEnumerable<int> sourceElements, Stack<int> destinationStack)
        {
            int numberOfElementsPushed = 0;

            foreach (var element in sourceElements)
            {
                destinationStack.Push(element);
                numberOfElementsPushed++;

                if (numberOfElementsPushed == numberOfElementsToPush)
                {
                    break;
                }
            }
        }
    }
}
