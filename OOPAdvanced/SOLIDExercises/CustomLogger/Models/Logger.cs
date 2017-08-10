namespace CustomLogger.Models
{
    using CustomLogger.Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class Logger : ILogger
    {
        private ICollection<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            if (appenders == null)
            {
                this.appenders = new List<IAppender>();
            }
            else
            {
                this.appenders = new List<IAppender>(appenders);
            }
        }

        public void Info(string datetime, string message)
        {
            this.InvokeAppenders(datetime, ReportLevel.Info, message);
        }

        public void Warning(string datetime, string message)
        {
            this.InvokeAppenders(datetime, ReportLevel.Warning, message);
        }

        public void Error(string datetime, string message)
        {
            this.InvokeAppenders(datetime, ReportLevel.Error, message);
        }

        public void Critical(string datetime, string message)
        {
            this.InvokeAppenders(datetime, ReportLevel.Critical, message);   
        }

        public void Fatal(string datetime, string message)
        {
            this.InvokeAppenders(datetime, ReportLevel.Fatal, message);
        }

        public void AddAppender(IAppender appender)
        {
            this.appenders.Add(appender);
        }

        private void InvokeAppenders(string datetime, ReportLevel reportLevel, string message)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(datetime, reportLevel, message);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Logger info");
            foreach (var appender in this.appenders)
            {
                result.AppendLine(appender.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
