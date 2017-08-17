namespace RecyclingStation.BusinessLogic.IO
{
    using RecyclingStation.BusinessLogic.Interfaces.IO;
    using System;
    using System.Text;

    public class ConsoleWriter : IWriter
    {
        private StringBuilder content;

        public ConsoleWriter()
            : this(new StringBuilder())
        {

        }

        public ConsoleWriter(StringBuilder content)
        {
            this.content = content;
        }

        public void AppendLine(string text)
        {
            this.content.AppendLine(text);
        }

        public void Write()
        {
            Console.Write(this.content.ToString());
        }
    }
}
