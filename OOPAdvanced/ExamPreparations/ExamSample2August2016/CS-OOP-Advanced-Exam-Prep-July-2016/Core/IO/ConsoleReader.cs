namespace CS_OOP_Advanced_Exam_Prep_July_2016.Core.IO
{
    using CS_OOP_Advanced_Exam_Prep_July_2016.Interfaces.IO;
    using System;

    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
