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
            switch (reportLevel)
            {
                case ReportLevel.Info:
                    return this.ReportLevel == ReportLevel.Info
                        || this.ReportLevel == ReportLevel.Warning
                        || this.ReportLevel == ReportLevel.Error
                        || this.ReportLevel == ReportLevel.Critical
                        || this.ReportLevel == ReportLevel.Fatal;
                case ReportLevel.Warning:
                    return this.ReportLevel == ReportLevel.Warning
                        || this.ReportLevel == ReportLevel.Error
                        || this.ReportLevel == ReportLevel.Critical
                        || this.ReportLevel == ReportLevel.Fatal;
                case ReportLevel.Error:
                    return this.ReportLevel == ReportLevel.Error
                        || this.ReportLevel == ReportLevel.Critical
                        || this.ReportLevel == ReportLevel.Fatal;
                case ReportLevel.Critical:
                    return this.ReportLevel == ReportLevel.Critical
                        || this.ReportLevel == ReportLevel.Fatal;
                case ReportLevel.Fatal:
                    return this.ReportLevel == ReportLevel.Fatal;
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
