namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var files = GetFilesFromDirectory();
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            SaveReport(files, desktopPath);
        }

        private static void SaveReport(Dictionary<string, Dictionary<string, long>> files, string dir)
        {
            var report = Path.Combine(dir, "report.txt");

            using (var writer = new StreamWriter(report))
            {
                foreach (var group in files
                    .OrderByDescending(g => g.Value.Count).ThenBy(g => g.Key))
                {
                    var filesInGroup = string.Join(Environment.NewLine, group.Value
                        .OrderByDescending(f => f.Value)
                        .Select(kvp => $"--{kvp.Key} - {kvp.Value}kb"));

                    writer.Write($"{group.Key}{Environment.NewLine}{filesInGroup}{Environment.NewLine}");
                }
            }
        }

        private static Dictionary<string, Dictionary<string, long>> GetFilesFromDirectory()
        {
            Console.Write("Enter Directory path: ");
            var dir = Console.ReadLine();

            while (!Directory.Exists(dir))
            {
                Console.WriteLine($@"This Directory does not exists. Please try again. You must enter the full path to your folder{Environment.NewLine}e.g. ""D:\Software-University-SoftUni\C# Advanced""");
                dir = Console.ReadLine();
            }
            var files = Directory.GetFiles(dir);

            // The files should be grouped by their extension
            // Dictionary<extension, Dictionary<filePath, fileSize>>
            var result = new Dictionary<string, Dictionary<string, long>>();

            foreach (var file in files)
            {
                var extension = Path.GetExtension(file);
                var fileSize = new FileInfo(file).Length;

                if (!result.ContainsKey(extension))
                {
                    result[extension] = new Dictionary<string, long>();
                }

                result[extension][file] = fileSize;
            }

            return result;
        }
    }
}
