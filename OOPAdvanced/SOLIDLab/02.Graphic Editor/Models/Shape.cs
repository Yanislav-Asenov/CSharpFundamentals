namespace _02.Graphic_Editor.Models
{
    using System;
    using _02.Graphic_Editor.Contracts;

    public class Shape : IShape
    {
        public virtual void Draw()
        {
            Console.WriteLine($"I'm {this.GetType().Name}");
        }
    }
}
