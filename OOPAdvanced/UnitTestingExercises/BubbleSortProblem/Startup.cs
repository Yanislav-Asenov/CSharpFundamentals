namespace BubbleSortProblem
{
    using BubbleSortProblem.Contracts;
    using BubbleSortProblem.Models;
    using System;

    public class Startup
    {
        public static void Main()
        {
            int[] numbers = new int[] { 2, 5, 1, 8, 9, 3, 19 };
            IBubble bubble = new Bubble();
            bubble.Sort(numbers);

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}