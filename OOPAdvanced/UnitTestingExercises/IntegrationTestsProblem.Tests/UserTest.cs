namespace IntegrationTestsProblem.Tests
{
    using IntegrationTestsProblem.Contracts;
    using IntegrationTestsProblem.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class UserTest
    {
        [Test]
        public void NameSetterShouldThrowArgumentNullExceptionWhenProvidedWithNullOrEmptyString()
        {
            string name = string.Empty;

            Assert.Throws<ArgumentNullException>(() =>
            {
                IUser user = new User(name);
            });
        }

        [Test]
        public void ConstructorWithNameShouldAssignName()
        {
            string name = "Test User Name";
            IUser user = new User(name);

            Assert.AreEqual(name, user.Name);
        }

        [Test]
        public void ConstructorWithNameAndCategoriesShouldThrowExceptionWhenCategoriesParameterIsNull()
        {
            string name = "Test User Name";
            List<ICategory> categories = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                IUser user = new User(name, categories);
            });
        }

        [Test]
        public void ConstructorWithNameAndCategoriesShouldAssignCategories()
        {
            string name = "Test User Name";
            List<ICategory> categories = new List<ICategory>()
            {
                new Category("Test Category Name")
            };

            IUser user = new User(name, categories);

            Assert.AreEqual(1, user.Categories.Count());
            Assert.AreEqual("Test Category Name", user.Categories.First().Name);
        }
    }
}
