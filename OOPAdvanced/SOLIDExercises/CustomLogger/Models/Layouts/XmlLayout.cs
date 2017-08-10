namespace CustomLogger.Models.Layouts
{
    using CustomLogger.Contracts;
    using System.Text;

    public class XmlLayout : ILayout
    {
        public string Layout
        {
            get
            {
                StringBuilder result = new StringBuilder();

                result.AppendLine("<log>")
                    .AppendLine("    <date>{0}</date>")
                    .AppendLine("    <level>{1}</level>")
                    .AppendLine("    <message>{2}</message>")
                    .Append("</log>");

                return result.ToString();
            }
        }
    }
}
