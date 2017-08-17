namespace RecyclingStation.BusinessLogic.Interfaces.IO
{
    public interface IWriter
    {
        void AppendLine(string text);

        void Write();
    }
}
