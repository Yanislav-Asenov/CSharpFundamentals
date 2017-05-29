using System;
using System.IO;

namespace BashSoft
{
    public class Launcher
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                IOManager.ChangeCurrentDirectoryRelative(input);

                OutputWriter.WriteMessageOnNewLine(SessionData.currentPath);

                input = Console.ReadLine();
            }
        }
    }
}
