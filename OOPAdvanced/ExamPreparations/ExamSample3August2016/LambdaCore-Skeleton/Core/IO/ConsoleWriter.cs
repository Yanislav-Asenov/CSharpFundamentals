namespace LambdaCore_Skeleton.Core.IO
{
    using System;
    using LambdaCore_Skeleton.Interfaces.Core.IO;

    public class ConsoleWriter : IOutputWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
