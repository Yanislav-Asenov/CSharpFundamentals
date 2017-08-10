namespace CustomLogger.Factories
{
    using CustomLogger.Contracts;
    using CustomLogger.Models.Layouts;
    using System;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout Create(string type)
        {
            switch (type)
            {
                case "SimpleLayout":
                    return new SimpleLayout();
                case "XmlLayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}
