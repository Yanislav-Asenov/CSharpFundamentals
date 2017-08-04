namespace IntegrationTestsProblem.Models
{
    using System.Collections.Generic;
    using IntegrationTestsProblem.Contracts;
    using System;

    public class User : IUser
    {
        private string name;
        private IList<ICategory> categories;

        public User(string name)
        {
            this.Name = name;
            this.categories = new List<ICategory>();
        }

        public User(string name, IEnumerable<ICategory> categories)
            : this(name)
        {
            this.categories = new List<ICategory>(categories);
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException();
                }

                this.name = value;
            }
        }

        public IEnumerable<ICategory> Categories => this.categories;
    }
}
