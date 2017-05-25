namespace BasicQueueOperations
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

            var numberOfElementsToEnqueue = arguments[0];
            var numberOfElementsToDequeue = arguments[1];
            var numberToCheck = arguments[2];

            // Get the second line of input args (input numbers).
            var sourceElements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var resultStack = new Queue<int>();

            EnqueueElements(numberOfElementsToEnqueue, sourceElements, resultStack);

            DequeueElements(numberOfElementsToDequeue, resultStack);

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

        private static void PrintSmallestElementInSequence(Queue<int> resultStack)
        {
            var minNumber = int.MaxValue;

            while (resultStack.Count > 0)
            {
                var currentNum = resultStack.Dequeue();

                if (currentNum < minNumber)
                {
                    minNumber = currentNum;
                }
            }

            Console.WriteLine(minNumber);
        }

        private static void DequeueElements(int numberOfElementsToPop, Queue<int> resultStack)
        {
            int numberOfDequeuedElements = 0;

            while (resultStack.Count > 0 && numberOfDequeuedElements != numberOfElementsToPop)
            {
                resultStack.Dequeue();
                numberOfDequeuedElements++;
            }
        }

        private static void EnqueueElements(int numberOfElementsToPush, IEnumerable<int> sourceElements, Queue<int> destinationStack)
        {
            int numberOfEnqueuedElements = 0;

            foreach (var element in sourceElements)
            {
                destinationStack.Enqueue(element);
                numberOfEnqueuedElements++;

                if (numberOfEnqueuedElements == numberOfElementsToPush)
                {
                    break;
                }
            }
        }
    }
}
