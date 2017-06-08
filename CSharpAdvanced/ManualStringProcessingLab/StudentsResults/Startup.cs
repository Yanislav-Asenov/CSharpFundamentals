namespace StudentsResults
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int numberOfInputLines = int.Parse(Console.ReadLine());
            List<string> inputLines = new List<string>();
          
            for (int i = 0; i < numberOfInputLines; i++)
            {
                inputLines.Add(Console.ReadLine());
            }

            Console.WriteLine("{0}|{1}|{2}|{3}|{4}|",
              "Name".PadRight(10),
              "CAdv".PadLeft(7),
              "COOP".PadLeft(7),
              "AdvOOP".PadLeft(7),
              "Average".PadLeft(7));

            for (int i = 0; i < inputLines.Count; i++)
            {
                string[] studentArgs = inputLines[i]
                    .Split(new[] { ' ', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);

                string studentName = studentArgs[0];
                double cSharpAdvMark = double.Parse(studentArgs[1]);
                double cSharpOOPMark = double.Parse(studentArgs[2]);
                double cSharpAdvOOPMark = double.Parse(studentArgs[3]);
                double average = (cSharpAdvMark + cSharpOOPMark + cSharpAdvOOPMark) / 3;

                Console.WriteLine("{0}|{1}|{2}|{3}|{4}|",
                studentName.PadRight(10),
                cSharpAdvMark.ToString("F2").PadLeft(7),
                cSharpOOPMark.ToString("F2").PadLeft(7),
                cSharpAdvOOPMark.ToString("F2").PadLeft(7),
                average.ToString("F4").PadLeft(7));
            }
        }
    }
}
