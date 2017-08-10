namespace CustomLogger.Models.Layouts
{
    using System;
    using CustomLogger.Contracts;

    public class SimpleLayout : ILayout
    {
        public string Layout
        {
            get
            {
                return "{0} - {1} - {2}";
            }
        }
    }
}
