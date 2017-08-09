namespace _01.Stream_Progress.Contracts
{
    public interface IFile
    {
        int Length { get; }

        int BytesSent { get; }
    }
}
