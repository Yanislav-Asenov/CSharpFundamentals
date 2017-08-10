namespace CustomLogger.Factories
{
    using CustomLogger.Contracts;
    using CustomLogger.Models;
    using System;

    public class ReportLevelFactory : IReportLevelFactory
    {
        public ReportLevel Create(string reportLevel)
        {
            switch (reportLevel.ToLower())
            {
                case "info":
                    return ReportLevel.Info;
                case "warning":
                    return ReportLevel.Warning;
                case "error":
                    return ReportLevel.Error;
                case "critical":
                    return ReportLevel.Critical;
                case "fatal":
                    return ReportLevel.Fatal;
                default:
                    throw new ArgumentException("Invalid report level!");
            }
        }
    }
}
