public class Program
{
    public static void Main()
    {
        var nationsBuilder = new NationsBuilder();
        var engine = new Engine(nationsBuilder);
        engine.Run();
    }
}