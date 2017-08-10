namespace CustomLogger.Contracts
{
    using CustomLogger.Models;

    public interface IAppender
    {
        void Append(string datetime, ReportLevel reportLevel, string message);
    }
}
