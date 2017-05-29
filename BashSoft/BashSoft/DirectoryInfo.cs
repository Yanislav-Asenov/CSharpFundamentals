﻿namespace BashSoft
{
    using System.Collections.Generic;
    using System.IO;

    public static class DirectoryInfo
    {
        public static void TraverseDirectory(string path)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = path.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(path);

            while (subFolders.Count > 0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;

                OutputWriter.WriteMessageOnNewLine($"{new string('-', identation)}{currentPath}");

                foreach (string directoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directoryPath);
                }
            }
        }
    }
}
