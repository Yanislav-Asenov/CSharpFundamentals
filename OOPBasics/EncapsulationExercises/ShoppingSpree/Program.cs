using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


public class Product
{
    private string name;
    private double price;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }
    public double Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.price = value;
        }
    }

    public Product(string name, double price)
    {
        this.Name = name;
        this.Price = price;
    }
}
public class Person
{
    private string name;
    private double money;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }

    public double Money
    {
        get { return this.money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }
    public List<Product> Bag { get; set; }
    public Person(string name, double money)
    {
        this.Name = name;
        this.Money = money;
        this.Bag = new List<Product>();
    }

    public void BuyProduct(Product prod)
    {
        if (this.Money >= prod.Price)
        {
            this.Money -= prod.Price;
            this.Bag.Add(prod);
        }
        else
        {
            throw new ArgumentException($"{this.Name} can't afford {prod.Name}");
        }
    }


}
class Program
{
    static void Main()
    {
        Dictionary<string, Person> allPersons = new Dictionary<string, Person>();
        Dictionary<string, Product> allProducts = new Dictionary<string, Product>();

        string[] persons = Console.ReadLine().Trim().Split(';');
        foreach (var person in persons)
        {
            string[] sep = person.Split('=');
            try
            {
                Person per = new Person(sep[0], double.Parse(sep[1]));

                allPersons.Add(per.Name, per);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

        }
        string[] products = Console.ReadLine().Trim().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var product in products)
        {
            string[] sep = product.Split('=');
            try
            {
                Product prod = new Product(sep[0], double.Parse(sep[1]));
                allProducts.Add(prod.Name, prod);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        string input = Console.ReadLine();
        while (input != "END")
        {
            string[] command = input.Split();
            try
            {
                allPersons[command[0]].BuyProduct(allProducts[command[1]]);
                Console.WriteLine($"{command[0]} bought {command[1]}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            input = Console.ReadLine();
        }

        foreach (var person in allPersons)
        {
            Console.Write($"{person.Key} - ");

            if (person.Value.Bag.Count < 1)
            {
                Console.WriteLine("Nothing bought");
            }
            else
            {

                Console.Write(string.Join(", ", person.Value.Bag.Select(x => x.Name)));
            }
            Console.WriteLine();
        }

    }
}