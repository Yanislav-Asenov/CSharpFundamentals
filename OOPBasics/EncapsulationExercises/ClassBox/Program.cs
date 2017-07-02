namespace ClassBox
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Program
    {
        public static void Main()
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            try
            {
                Box box = new Box(length, width, height);
                Console.WriteLine($"Surface Area - {box.SurfaceArea:F2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea:F2}");
                Console.WriteLine($"Volume - {box.Volume:F2}");
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
        }
    }
}