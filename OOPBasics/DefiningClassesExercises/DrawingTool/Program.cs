using System;

public class Program
{
    public static void Main()
    {
        string targetFigure = Console.ReadLine();
        int width = int.Parse(Console.ReadLine());
        CorDraw corDraw;

        if (targetFigure == "Rectangle")
        {
            int height = int.Parse(Console.ReadLine());
            corDraw = new CorDraw(new Rectangle(width, height));
        }
        else
        {
            corDraw = new CorDraw(new Square(width));
        }

        corDraw.DrawFigure();
    }
}

public class CorDraw
{
    public Figure Figure { get; set; }

    public CorDraw(Figure figure)
    {
        this.Figure = figure;
    }

    public void DrawFigure()
    {
        this.Figure.Draw();
    }
}

public abstract class Figure
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Figure(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public void Draw()
    {
        for (int row = 0; row < this.Height; row++)
        {
            if (row == 0 || row == this.Height - 1)
            {
                Console.WriteLine($"|{new string('-', this.Width)}|");
            }
            else
            {
                Console.WriteLine($"|{new string(' ', this.Width)}|");
            }
        }
    }
}

public class Square : Figure
{
    public Square(int size)
        : base(size, size)
    {
    }
}

public class Rectangle : Figure
{
    public Rectangle(int width, int height)
        : base(width, height)
    {
    }
}