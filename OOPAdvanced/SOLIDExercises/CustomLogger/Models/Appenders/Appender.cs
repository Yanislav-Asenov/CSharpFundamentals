namespace CustomLogger.Models.Appenders
{
    using CustomLogger.Contracts;

    public abstract class Appender : IAppender
    {
        protected readonly ILayout layout;
        private ReportLevel reportLevel = ReportLevel.Info;
        protected int appendCounter;

        public Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public Appender(ILayout layout, ReportLevel reportLevel)
            : this(layout)
        {
            this.reportLevel = reportLevel;
        }

        public ReportLevel ReportLevel
        {
            get => this.reportLevel;
            set => this.reportLevel = value;
        }

        public int AppendCounter => this.appendCounter;

        public abstract void Append(string datetime, ReportLevel reportLevel, string message);

        protected bool IsReportLevelInRange(ReportLevel reportLevel)
        {
            switch (this.ReportLevel)
            {
                case ReportLevel.Info:
                    return reportLevel == ReportLevel.Info
                        || reportLevel == ReportLevel.Warning
                        || reportLevel == ReportLevel.Error
                        || reportLevel == ReportLevel.Critical
                        || reportLevel == ReportLevel.Fatal;
                case ReportLevel.Warning:
                    return reportLevel == ReportLevel.Warning
                        || reportLevel == ReportLevel.Error
                        || reportLevel == ReportLevel.Critical
                        || reportLevel == ReportLevel.Fatal;
                case ReportLevel.Error:
                    return reportLevel == ReportLevel.Error
                        || reportLevel == ReportLevel.Critical
                        || reportLevel == ReportLevel.Fatal;
                case ReportLevel.Critical:
                    return reportLevel == ReportLevel.Critical
                        || reportLevel == ReportLevel.Fatal;
                case ReportLevel.Fatal:
                    return reportLevel == ReportLevel.Fatal;
                default:
                    return false;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.AppendCounter}";
        }
    }
}
