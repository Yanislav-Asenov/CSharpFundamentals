namespace CustomLogger.Models
{
    using CustomLogger.Contracts;
    using System.Text;

    public class LogFile : ILogFile
    {
        private StringBuilder content;
        private int size;

        public LogFile()
        {
            this.content = new StringBuilder();
        }

        public int Size => this.size;

        public string Content => this.content.ToString().Trim();

        public void Write(string message)
        {
            this.content.AppendLine(message);
            this.IncreaseSize(message);
        }

        private void IncreaseSize(string message)
        {
            foreach (var ch in message)
            {
                if (char.IsLetter(ch))
                {
                    this.size += ch;
                }
            }
        }
    }
}