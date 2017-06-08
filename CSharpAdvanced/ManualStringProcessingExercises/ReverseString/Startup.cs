namespace ReverseString
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            string inputString = Console.ReadLine();
            StringBuilder reversedString = new StringBuilder();
            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                reversedString.Append(inputString[i]);
            }

            Console.WriteLine(reversedString);
        }
    }
}
