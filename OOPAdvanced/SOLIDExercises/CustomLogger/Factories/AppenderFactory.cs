namespace CustomLogger.Factories
{
    using System;
    using CustomLogger.Contracts;
    using CustomLogger.Models.Appenders;
    using CustomLogger.Models;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender Create(string type, ReportLevel reportLevel, ILayout layout)
        {
            switch (type)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout, reportLevel);
                case "FileAppender":
                    return new FileAppender(layout, reportLevel, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
