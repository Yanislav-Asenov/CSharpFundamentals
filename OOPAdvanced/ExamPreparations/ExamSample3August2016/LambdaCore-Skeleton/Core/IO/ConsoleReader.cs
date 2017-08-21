namespace LambdaCore_Skeleton.Core.IO
{
    using LambdaCore_Skeleton.Interfaces.Core.IO;
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
