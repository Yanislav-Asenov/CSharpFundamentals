public class Startup
{
    public static void Main()
    {
        Scale<int> ints = new Scale<int>(20, 15);
        System.Console.WriteLine(ints.GetHavier());
    }
}