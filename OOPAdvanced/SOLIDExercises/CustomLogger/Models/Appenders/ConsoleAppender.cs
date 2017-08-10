namespace CustomLogger.Models.Appenders
{
    using System;
    using CustomLogger.Contracts;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public ConsoleAppender(ILayout layout, ReportLevel reportLevel)
            : base(layout, reportLevel)
        {
        }

        public override void Append(string datetime, ReportLevel reportLevel, string message)
        {
            if (this.IsReportLevelInRange(reportLevel))
            {
                string result = string.Format(this.layout.Layout,
                    datetime,
                    reportLevel.ToString().ToUpper(),
                    message);

                Console.WriteLine(result);
                this.appendCounter++;
            }
        }
    }
}
