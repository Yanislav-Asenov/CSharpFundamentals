namespace CharacterMultiplier
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] inputArgs = Console.ReadLine().Split();
            string firstWord = inputArgs[0];
            string secondWord = inputArgs[1];

            int totalSum = 0;
            for (int i = 0; i < firstWord.Length && i < secondWord.Length; i++)
            {
                totalSum += firstWord[i] * secondWord[i];
            }

            if (firstWord.Length > secondWord.Length)
            {
                for (int i = secondWord.Length; i < firstWord.Length; i++)
                {
                    totalSum += firstWord[i];
                }
            }
            else
            {
                for (int i = firstWord.Length; i < secondWord.Length; i++)
                {
                    totalSum += secondWord[i];
                }
            }

            Console.WriteLine(totalSum);
        }
    }
}
