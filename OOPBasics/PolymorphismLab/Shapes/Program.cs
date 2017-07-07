public class Program
{
    public static void Main(string[] args)
    {
        var test = new Circle(5);
        System.Console.WriteLine(test.CalculateArea());
        System.Console.WriteLine(test.CalculatePerimeter());
        System.Console.WriteLine(test.Draw());
    }
}

