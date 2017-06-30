namespace AppliedAritmethics
{
    using System;
    using System.Linq;

    public class Startup
    {
        private static Func<int[], int[]> addOne = numbers => numbers.Select(x => x + 1).ToArray();
        private static Func<int[], int[]> multiplyByTwo = numbers => numbers.Select(x => x * 2).ToArray();
        private static Func<int[], int[]> subtractOne = numbers => numbers.Select(x => x - 1).ToArray();
        private static Action<int[]> printNumbers = x => Console.WriteLine(string.Join(" ", x));

        public static void Main()
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = Console.ReadLine();
            while (command.ToLower() != "end")
            {
                switch (command)
                {
                    case "add":
                        inputNumbers = addOne(inputNumbers);
                        break;
                    case "multiply":
                        inputNumbers = multiplyByTwo(inputNumbers);
                        break;
                    case "subtract":
                        inputNumbers = subtractOne(inputNumbers);
                        break;
                    case "print":
                        printNumbers(inputNumbers);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
