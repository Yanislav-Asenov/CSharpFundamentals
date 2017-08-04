namespace IntegrationTestsProblem.Models
{
    using System;
    using System.Collections.Generic;
    using IntegrationTestsProblem.Contracts;

    public class WebSite : IWebSite
    {
        private IDictionary<string, ICategory> categories;
        private IDictionary<string, IUser> users;

        public WebSite()
        {
            this.categories = new Dictionary<string, ICategory>();
            this.users = new Dictionary<string, IUser>();
        }

        public IDictionary<string, ICategory> Categories => this.categories;

        public IDictionary<string, IUser> Users => this.users;

        public void AddCategory(ICategory category)
        {
            if (category is null)
            {
                throw new ArgumentNullException();
            }

            if (this.categories.ContainsKey(category.Name))
            {
                throw new InvalidOperationException();
            }

            this.categories.Add(category.Name, category);
        }

        public void AddUser(IUser user)
        {
            if (user is null)
            {
                throw new ArgumentNullException();
            }

            if (this.categories.ContainsKey(user.Name))
            {
                throw new InvalidOperationException();
            }

            this.users.Add(user.Name, user);
        }

        public ICategory GetCategoryByName(string name)
        {
            if (!this.categories.ContainsKey(name))
            {
                throw new InvalidOperationException();
            }

            return this.categories[name];
        }

        public IUser GetUserByName(string name)
        {
            if (!this.users.ContainsKey(name))
            {
                throw new InvalidOperationException();
            }

            return this.users[name];
        }
    }
}