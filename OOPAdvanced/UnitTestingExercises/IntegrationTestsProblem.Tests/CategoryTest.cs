namespace IntegrationTestsProblem.Tests
{
    using IntegrationTestsProblem.Contracts;
    using IntegrationTestsProblem.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class CategoryTest
    {
        [Test]
        public void ConstructorWithNameShouldWork()
        {
            var categoryName = "Test Category";
            var category = new Category(categoryName);

            Assert.AreEqual(categoryName, category.Name, "Constructor does not assign name correctly");
        }

        [Test]
        public void ConstructorWithNameAndUsersShouldThrowExceptionWhenProvidedUsersParameterIsNull()
        {
            var categoryName = "Test Category";
            List<IUser> users = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var category = new Category(categoryName, users);
            });
        }

        [Test]
        public void ConstructorWithNameAndUsersShouldWork()
        {
            var categoryName = "Test Category";
            var users = new List<IUser>()
            {
                new User("Test User")
            };

            var category = new Category(categoryName, users);

            Assert.AreEqual(categoryName, category.Name);
            Assert.AreEqual(1, category.Users.Count());
        }

        [Test]
        public void ConstructorWithNameAndCategoriesShouldThrowExceptionWhenProvidedCategoriesParameterIsNull()
        {
            var categoryName = "Test Category";
            List<ICategory> categories = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var category = new Category(categoryName, categories);
            });
        }

        [Test]
        public void ConstructorWithNameAndCategoriesShouldWork()
        {
            var categoryName = "Test Category";
            var categories = new List<ICategory>()
            {
                new Category("Test Subcategory")
            };

            var category = new Category(categoryName, categories);

            Assert.AreEqual(categoryName, category.Name);
            Assert.AreEqual(1, category.Subcategories.Count());
        }

        [Test]
        public void ConstructorWithNameUsersAndCategoriesShouldWork()
        {
            var categoryName = "Test Category";
            var users = new List<IUser>()
            {
                new User("Test User")
            };
            var categories = new List<ICategory>()
            {
                new Category("Test Subcategory")
            };

            var category = new Category(categoryName, users, categories);
            Assert.AreEqual(categoryName, category.Name);
            Assert.AreEqual(1, category.Users.Count());
            Assert.AreEqual(1, category.Subcategories.Count());
        }

        [Test]
        public void NameSetterShouldThorwArgumentNullExceptionWhenProvidedValueIsNull()
        {
            string name = null;
            Assert.Throws<ArgumentNullException>(() => new Category(name));
        }

        [Test]
        public void AddSubcategoryShouldThrowArgumentNullExceptionNWhenProvidedCategoryIsSNull()
        {
            ICategory category = new Category("Test Category");
            ICategory subcategory = null;
            Assert.Throws<ArgumentNullException>(() => 
            {
                category.AddSubcategory(subcategory);
            });
        }

        [Test]
        public void AddSubcategoryShouldThrowInvalidOperationExceptionWhenCategoryWithTheSameNameAlreadyExists()
        {
            ICategory category = new Category("Test Category");
            ICategory subcategory = new Category("Test Subcategory");
            category.AddSubcategory(subcategory);
            Assert.Throws<InvalidOperationException>(() =>
            {
                category.AddSubcategory(subcategory);
            });
        }

        [Test]
        public void AddSubcategoryShouldWorkWhenProvidedWithValidCategory()
        {
            ICategory category = new Category("Test Category");
            ICategory subcategory = new Category("Test Subcategory");
            category.AddSubcategory(subcategory);

            Assert.AreEqual(1, category.Subcategories.Count());
            Assert.AreEqual(subcategory.Name, category.Subcategories.First().Name);
        }
    }
}