namespace SlicingFile
{
    using System.IO;

    public class Startup
    {
        private const string InputTestFile = "../../test_image.jpg";
        private const string OutputFile = "../../result.jpg";

        public static void Main()
        {
            using (FileStream stream = File.OpenRead(InputTestFile))
            using (FileStream writeStream = File.OpenWrite(OutputFile))
            {
                BinaryReader reader = new BinaryReader(stream);
                BinaryWriter writer = new BinaryWriter(writeStream);

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, 1024);

                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);

                    bytesRead = stream.Read(buffer, 0, 1024);
                }
            }
        }
    }
}
