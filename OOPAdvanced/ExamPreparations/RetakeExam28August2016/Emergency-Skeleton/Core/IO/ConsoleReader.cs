namespace Emergency_Skeleton.Core.IO
{
    using Emergency_Skeleton.Interfaces.Core.IO;
    using System;

    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            string result = Console.ReadLine();
            return result;
        }
    }
}
