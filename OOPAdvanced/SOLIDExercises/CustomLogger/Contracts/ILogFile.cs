namespace CustomLogger.Contracts
{
    public interface ILogFile
    {
        void Write(string message);

        int Size { get; }

        string Content { get; }
    }
}
