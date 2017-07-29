public class Startup
{
    [SoftUni("Yani")]
    [SoftUni("Gosho")]
    public static void Main()
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}