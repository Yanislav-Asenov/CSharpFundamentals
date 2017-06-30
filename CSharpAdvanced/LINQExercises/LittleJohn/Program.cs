namespace _12.LittleJohn
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class LittleJohn
    {
        public static void Main()
        {
            string smallArrow = ">----->";
            string mediumArrow = ">>----->";
            string largeArrow = ">>>----->>";
            string pattern = @"([>]{1,3}[-]{5}[>]{1,2})";

            int smallArrowsCount = 0;
            int mediumArrowsCount = 0;
            int largeArrowsCount = 0;

            Regex regex = new Regex(pattern);

            string[] inputLines = new string[4];

            for (int i = 0; i < 4; i++)
            {
                inputLines[i] = Console.ReadLine();

            }


            for (int i = 0; i < inputLines.Length; i++)
            {
                string inputLine = inputLines[i];

                MatchCollection matches = regex.Matches(inputLine);

                foreach (var match in matches)
                {
                    if (match.ToString() == largeArrow)
                    {
                        largeArrowsCount++;
                        inputLine = inputLine.Replace(match.ToString(), "");
                    }
                }
            }



            for (int i = 0; i < inputLines.Length; i++)
            {
                string inputLine = inputLines[i];

                MatchCollection matches = regex.Matches(inputLine);

                foreach (var match in matches)
                {
                    if (match.ToString() == mediumArrow)
                    {
                        mediumArrowsCount++;
                        inputLine = inputLine.Replace(match.ToString(), "");
                    }
                }
            }



            for (int i = 0; i < inputLines.Length; i++)
            {
                string inputLine = inputLines[i];

                MatchCollection matches = regex.Matches(inputLine);

                foreach (var match in matches)
                {
                    if (match.ToString() == smallArrow)
                    {
                        smallArrowsCount++;
                        inputLine = inputLine.Replace(match.ToString(), "");
                    }
                }
            }

            int arrowsCountConcatenated = int.Parse("" + smallArrowsCount + mediumArrowsCount + largeArrowsCount);

            string initialBinary = Convert.ToString(arrowsCountConcatenated, 2);

            string reversedInitialBinary = string.Join("", initialBinary.ToCharArray().Reverse());

            string binaryResult = initialBinary + reversedInitialBinary;

            decimal finalDecimalResult = Convert.ToInt32(binaryResult, 2);

            Console.WriteLine(finalDecimalResult);
        }
    }
}
