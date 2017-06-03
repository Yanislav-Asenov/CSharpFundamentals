







namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class Startup
    {
        private const string InputTestFile = "../../input_video.mkv";
        private const string OutputFile = "../../result_video.mkv";

        public static void Main()
        {
            int parts = 4;

            SliceFile(InputTestFile, OutputFile, parts);
        }

        private static void SliceFile(string inputTestFile, string outputFile, int parts)
        {
            using (FileStream srcFile = File.OpenRead(InputTestFile))
            {
                BinaryReader reader = new BinaryReader(srcFile);

                byte[] buffer = new byte[srcFile.Length / parts];
                int bytesRead = srcFile.Read(buffer, 0, buffer.Length);

                for (int i = 0; i < parts; i++)
                {
                    string destinationFile = $"../../{i}_result_video.mkv";
                    long partSize = srcFile.Length / parts + srcFile.Length % parts;

                    using (FileStream destinationDir = File.OpenWrite(destinationFile))
                    {
                        BinaryWriter writer = new BinaryWriter(destinationDir);
                        destinationDir.Write(buffer, 0, bytesRead);

                        bytesRead = srcFile.Read(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
