namespace CustomLogger.Contracts
{
    using CustomLogger.Models;

    public interface IAppenderFactory
    {
        IAppender Create(string type, ReportLevel reportLevel, ILayout layout);
    }
}
