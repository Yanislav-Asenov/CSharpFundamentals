namespace _13.OfficeStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OfficeStuff
    {
        public static void Main()
        {
            int numberOfInputLines = int.Parse(Console.ReadLine());
            List<Company> companies = new List<Company>();

            for (int i = 0; i < numberOfInputLines; i++)
            {
                string[] inputArgs = Console.ReadLine().Trim('|').Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string companyName = inputArgs[0].Trim();
                int productPrice = int.Parse(inputArgs[1].Trim());
                string productName = inputArgs[2].Trim();

                if (companies.FirstOrDefault(c => c.Name == companyName) == null)
                {
                    companies.Add(new Company(companyName));
                }

                var currentCompany = companies.First(c => c.Name == companyName);

                if (currentCompany.ContainsProduct(productName))
                {
                    currentCompany.FindProductByName(productName).Price += productPrice;
                }
                else
                {
                    currentCompany.Products.Add(new Product { Name = productName, Price = productPrice });
                }
            }

            foreach (var company in companies.OrderBy(c => c.Name))
            {
                Console.WriteLine($"{company.Name}: {company.GetAllProducts()}");
            }
        }
    }

    public class Company
    {
        public Company(string name)
        {
            this.Name = name;
            this.Products = new List<Product>();
        }

        public string Name { get; set; }

        public List<Product> Products { get; set; }

        public bool ContainsProduct(string productName)
        {
            if (this.Products.FirstOrDefault(p => p.Name == productName) == null)
            {
                return false;
            }

            return true;
        }

        public Product FindProductByName(string productName)
        {
            return this.Products.FirstOrDefault(p => p.Name == productName);
        }

        public string GetAllProducts()
        {
            List<string> productsInfoAsStrings = new List<string>();

            foreach (var product in this.Products)
            {
                string currentProduct = $"{product.Name}-{product.Price}";
                productsInfoAsStrings.Add(currentProduct);
            }

            return string.Join(", ", productsInfoAsStrings);
        }
    }

    public class Product
    {
        public string Name { get; set; }

        public int Price { get; set; }
    }
}
