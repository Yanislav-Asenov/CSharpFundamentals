namespace SequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            var resultQueue = new Queue<long>();
            resultQueue.Enqueue(n);

            StringBuilder resultSequence = new StringBuilder();
            for (int i = 0; i < 50; i++)
            {
                var firstInQueue = resultQueue.Peek();
                resultQueue.Enqueue(firstInQueue + 1);
                resultQueue.Enqueue(2 * firstInQueue + 1);
                resultQueue.Enqueue(firstInQueue + 2);


                resultSequence.Append(resultQueue.Dequeue() + " ");
            }

            Console.WriteLine(resultSequence.ToString().TrimEnd());
        }
    }
}
