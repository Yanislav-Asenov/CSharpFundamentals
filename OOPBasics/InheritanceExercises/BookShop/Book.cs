using System;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    protected virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            price = value;
        }
    }

    protected virtual string Author
    {
        get { return author; }
        set
        {
            string[] authorNames = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (authorNames.Length >= 2 && char.IsDigit(authorNames[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }

            author = value;
        }
    }

    protected string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            this.title = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Type: ").AppendLine(this.GetType().Name)
            .Append("Title: ").AppendLine(this.Title)
            .Append("Author: ").AppendLine(this.Author)
            .Append("Price: ").Append($"{this.Price:f1}")
            .AppendLine();

        return sb.ToString();
    }
}

