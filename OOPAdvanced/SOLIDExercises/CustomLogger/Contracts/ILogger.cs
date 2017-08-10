namespace CustomLogger.Contracts
{
    public interface ILogger
    {
        void Info(string datetime, string message);

        void Warning(string datetime, string message);

        void Error(string datetime, string message);

        void Critical(string datetime, string message);

        void Fatal(string datetime, string message);

        void AddAppender(IAppender appender);
    }
}
