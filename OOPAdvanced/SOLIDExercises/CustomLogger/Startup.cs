namespace CustomLogger
{
    using CustomLogger.Contracts;
    using CustomLogger.Factories;
    using CustomLogger.Models;

    public class Startup
    {
        public static void Main()
        {
            ILayoutFactory layoutFactory = new LayoutFactory();
            IAppenderFactory appenderFactory = new AppenderFactory();
            IReportLevelFactory reportLevelFactory = new ReportLevelFactory();

            ILogger logger = new Logger();
            IRunnable engine = new Engine(logger, layoutFactory, appenderFactory, reportLevelFactory);
            engine.Run();
        }
    }
}
