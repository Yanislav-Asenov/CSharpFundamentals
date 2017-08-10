namespace CustomLogger.Models
{
    using System;
    using CustomLogger.Contracts;
    using System.Collections.Generic;

    public class Engine : IRunnable
    {
        private readonly IReportLevelFactory reportLevelFactory;
        private readonly ILayoutFactory layoutFactory;
        private readonly IAppenderFactory appenderFactory;
        private readonly ILogger logger;

        public Engine(
            ILogger logger, 
            ILayoutFactory layoutFactory, 
            IAppenderFactory appenderFactory, 
            IReportLevelFactory reportLevelFactory)
        {
            this.layoutFactory = layoutFactory;
            this.appenderFactory = appenderFactory;
            this.reportLevelFactory = reportLevelFactory;
            this.logger = logger;
        }

        public void Run()
        {
            this.SetupLogger();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input.Split('|');

                string reportLevel = inputArgs[0].ToUpper();
                reportLevel = $"{reportLevel[0] + reportLevel.ToLower().Substring(1)}";

                string datetime = inputArgs[1];
                string message = inputArgs[2];

                var loggerType = this.logger.GetType();
                var targetMethod = loggerType.GetMethod(reportLevel);
                targetMethod.Invoke(this.logger, new object[] { datetime, message });

                input = Console.ReadLine();
            }

            Console.WriteLine(this.logger);
        }

        private void SetupLogger()
        {
            int numberOfAppenders = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();
            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] layoutArgs = Console.ReadLine().Split();
                string appenderType = layoutArgs[0];
                string layoutType = layoutArgs[1];
                string reportLevelAsString = layoutArgs.Length == 3 ? layoutArgs[2] : "info";

                ReportLevel reportLevel = this.reportLevelFactory.Create(reportLevelAsString);
                ILayout layout = this.layoutFactory.Create(layoutType);
                IAppender appender = this.appenderFactory.Create(appenderType, reportLevel, layout);
                this.logger.AddAppender(appender);
            }
        }
    }
}
