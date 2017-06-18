namespace CustomMinFunction
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Func<int[], int> getMin = (numbers) => numbers.Min();
            int[] numbersArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(getMin(numbersArr));
        }
    }
}
