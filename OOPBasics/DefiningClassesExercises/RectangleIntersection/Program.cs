using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] inputArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int numberOfRectangles = inputArgs[0];
        int numberOfIntersectionChecks = inputArgs[1];

        Dictionary<string, Rectangle> rectanglesByIds = new Dictionary<string, Rectangle>();
        for (int i = 0; i < numberOfRectangles; i++)
        {
            string[] rectangleArgs = Console.ReadLine().Split();
            string id = rectangleArgs[0];
            double width = double.Parse(rectangleArgs[1]);
            double height = double.Parse(rectangleArgs[2]);
            double x = double.Parse(rectangleArgs[3]);
            double y = double.Parse(rectangleArgs[4]);

            rectanglesByIds.Add(id, new Rectangle(id, width, height, x, y));
        }

        for (int i = 0; i < numberOfIntersectionChecks; i++)
        {
            string[] commandArgs = Console.ReadLine().Split();
            Rectangle first = rectanglesByIds[commandArgs[0]];
            Rectangle second = rectanglesByIds[commandArgs[1]];

            if (first.IntersectionCheck(second))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}

public class Rectangle
{
    public string ID { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double X { get; set; }
    public double Y { get; set; }

    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.ID = id;
        this.Width = width;
        this.Height = height;
        this.X = x;
        this.Y = y;
    }

    public bool IntersectionCheck(Rectangle rect)
    {
        return !(this.X > rect.X + rect.Width || 
            this.X + this.Width < rect.X || 
            this.Y > rect.Y + rect.Height || 
            this.Y + this.Height < rect.Y);
    }
}