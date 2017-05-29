namespace BashSoft
{
    using System;
    using System.IO;

    public static class IOManager
    {
        public static void CreateDirectoryInCurrentFolder(string name)
        {
            string path = $@"{GetCurrentDirectoryPath()}\{name}";
            Directory.CreateDirectory(path);
        }

        private static object GetCurrentDirectoryPath()
        {
            return SessionData.currentPath;
        }

        public static void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                string currentPath = SessionData.currentPath;
                int indexOfLastSlash = currentPath.LastIndexOf('\\');

                if (indexOfLastSlash == -1)
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                    return;
                }

                string newPath = currentPath.Substring(0, indexOfLastSlash);
                SessionData.currentPath = newPath;
            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        private static void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                return;
            }

            SessionData.currentPath = absolutePath;
        }
    }
}
