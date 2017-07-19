using System;
using System.Text;

public class Circle : IDrawable
{
    private int radius;

    public Circle(int radius)
    {
        this.Radius = radius;
    }

    public int Radius
    {
        get { return radius; }
        private set { radius = value; }
    }

    public void Draw()
    {
        double radiusIn = this.Radius - 0.4;
        double radiusOut = this.Radius + 0.4;

        StringBuilder result = new StringBuilder();
        for (double y = this.Radius; y >= -this.Radius; --y)
        {
            for (double x = -this.Radius; x < radiusOut; x += 0.5)
            {
                double value = x * x + y * y;

                if (value >= radiusIn * radiusIn && value <= radiusOut * radiusOut)
                {
                    result.Append("*");
                }
                else
                {
                    result.Append(" ");
                }
            }

            result.AppendLine();
        }

        Console.WriteLine(result.ToString().TrimEnd());
    }
}