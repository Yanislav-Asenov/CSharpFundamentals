namespace BashSoft.StaticData
{
    using System.IO;

    public static class SessionData
    {
        private static string currentPath;

        public static string CurrentPath
        {
            get
            {
                if (string.IsNullOrEmpty(currentPath))
                {
                    currentPath = Directory.GetCurrentDirectory();
                }

                return currentPath;
            }

            set => currentPath = value;
        }
    }
}
