namespace CustomLogger.Contracts
{
    using CustomLogger.Models;

    public interface IReportLevelFactory
    {
        ReportLevel Create(string reportLevel);
    }
}
