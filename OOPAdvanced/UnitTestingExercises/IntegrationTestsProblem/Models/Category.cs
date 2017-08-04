namespace IntegrationTestsProblem.Models
{
    using System.Collections.Generic;
    using IntegrationTestsProblem.Contracts;
    using System;
    using System.Linq;

    public class Category : ICategory
    {
        private string name;
        private IList<IUser> users;
        private IList<ICategory> subcategories;

        public Category(string name)
        {
            this.Name = name;
            this.users = new List<IUser>();
            this.subcategories = new List<ICategory>();
        }

        public Category(string name, IEnumerable<IUser> users)
            : this(name)
        {
            this.users = new List<IUser>(users);
        }

        public Category(string name, IEnumerable<IUser> users, IEnumerable<ICategory> categories)
            : this(name, users)
        {
            this.subcategories = new List<ICategory>(categories);
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value is null)
                {
                    throw new ArgumentNullException();
                }

                this.name = value;
            }
        }

        public IEnumerable<IUser> Users => this.users;

        public IEnumerable<ICategory> Subcategories => this.subcategories;

        public void AddSubcategory(ICategory category)
        {
            if (category is null)
            {
                throw new ArgumentNullException();
            }

            if (this.subcategories.Any(sc => sc.Name == category.Name))
            {
                throw new InvalidOperationException();
            }

            this.subcategories.Add(category);
        }
    }
}