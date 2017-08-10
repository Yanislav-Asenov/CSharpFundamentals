namespace CustomLogger.Models.Appenders
{
    using CustomLogger.Contracts;

    public class FileAppender : Appender, IFileAppender
    {
        private ILogFile file;

        public FileAppender(ILayout layout, ILogFile file) 
            : base(layout)
        {
            this.file = file;
        }

        public FileAppender(ILayout layout, ReportLevel reportLevel, ILogFile file) 
            : base(layout, reportLevel)
        {
            this.file = file;
        }

        public ILogFile File
        {
            get => this.file;
            set => this.file = value;
        }

        public override void Append(string datetime, ReportLevel reportLevel, string message)
        {
            if (this.IsReportLevelInRange(reportLevel))
            {
                string result = string.Format(this.layout.Layout,
                datetime,
                reportLevel.ToString().ToUpper(),
                message);

                this.File.Write(result);
                this.appendCounter++;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, File size {this.File.Size}";
        }
    }
}
