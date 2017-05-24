namespace HotPotato
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var inputNames = Console.ReadLine().Split(' ');
            int targetTossValue = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();

            foreach (var name in inputNames)
            {
                queue.Enqueue(name);
            }

            int tossCounter = 1;
            while (queue.Count > 1)
            {
                if (tossCounter % targetTossValue == 0)
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }
                else
                {
                    queue.Enqueue(queue.Dequeue());
                }

                tossCounter++;
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}