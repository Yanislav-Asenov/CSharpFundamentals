namespace MathPotato
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
            int cycles = 1;
            while (queue.Count > 1)
            {
                if (tossCounter % targetTossValue == 0)
                {
                    if (!IsPrime(cycles))
                    {
                        Console.WriteLine($"Removed {queue.Dequeue()}");
                    }
                    else
                    {
                        Console.WriteLine($"Prime {queue.Peek()}");
                    }

                    cycles++;
                }
                else
                {
                    queue.Enqueue(queue.Dequeue());
                }

                tossCounter++;
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }

        private static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
