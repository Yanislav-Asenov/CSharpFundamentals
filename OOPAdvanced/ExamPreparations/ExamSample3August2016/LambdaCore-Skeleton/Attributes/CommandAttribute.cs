namespace LambdaCore_Skeleton.Attributes
{
    using System;

    public class CommandAttribute : Attribute
    {
        private string name;

        public CommandAttribute(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
    }
}
