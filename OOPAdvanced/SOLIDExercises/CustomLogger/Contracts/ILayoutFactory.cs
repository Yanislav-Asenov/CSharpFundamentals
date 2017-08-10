namespace CustomLogger.Contracts
{
    public interface ILayoutFactory
    {
        ILayout Create(string type);
    }
}
