namespace KingsGambit.Models
{
    using KingsGambit.Contracts;
    using System;

    public class Entity : IEntity
    {
        private string name;

        public Entity(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.Name));
                }

                this.name = value;
            }
        }
    }
}
