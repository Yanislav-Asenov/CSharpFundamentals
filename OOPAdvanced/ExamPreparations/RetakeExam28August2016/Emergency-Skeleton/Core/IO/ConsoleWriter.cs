namespace Emergency_Skeleton.Core.IO
{
    using Emergency_Skeleton.Interfaces.Core.IO;
    using System;

    public class ConsoleWriter : IOutputWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
