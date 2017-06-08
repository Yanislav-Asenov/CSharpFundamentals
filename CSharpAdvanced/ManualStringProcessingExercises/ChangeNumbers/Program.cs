namespace LettersChangeNumbers
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] inputSequences = Console.ReadLine().Split(new[] { ' ', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            decimal resultSum = 0;
            foreach (var sequence in inputSequences)
            {
                resultSum += GetSequenceValue(sequence);
            }

            Console.WriteLine(resultSum.ToString("F2"));
        }

        private static decimal GetSequenceValue(string sequence)
        {

            char letterBeforeNumber = sequence[0];
            char letterAfterNumber = sequence[sequence.Length - 1];

            decimal number = decimal.Parse(sequence.Substring(1, sequence.Length - 2));

            if (char.IsUpper(letterBeforeNumber))
            {
                int letterPosition = (letterBeforeNumber - 64);
                number /= letterPosition;
            }
            else
            {
                int letterPosition = (letterBeforeNumber - 96);
                number *= letterPosition;
            }

            if (char.IsUpper(letterAfterNumber))
            {
                int letterPosition = (letterAfterNumber - 64);
                number -= letterPosition;
            }
            else
            {
                int letterPosition = (letterAfterNumber - 96);
                number += letterPosition;
            }

            return number;
        }
    }
}
