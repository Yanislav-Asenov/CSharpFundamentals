namespace _01.Stream_Progress.Models
{
    using _01.Stream_Progress.Contracts;

    public class StreamProgressInfo
    {
        private IFile file;

        public StreamProgressInfo(IFile file)
        {
            this.file = file;
        }

        public int CalculateCurrentPercent()
        {
            return (this.file.BytesSent * 100) / this.file.Length;
        }
    }
}
