namespace CustomLogger.Contracts
{
    public interface IFileAppender
    {
        ILogFile File { get; }
    }
}
