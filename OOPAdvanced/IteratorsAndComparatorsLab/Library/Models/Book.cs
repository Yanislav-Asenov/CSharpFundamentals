using System;
using System.Collections.Generic;

public class Book : IBook, IComparable<Book>
{
    private string title;
    private int year;
    private IReadOnlyCollection<string> authors;

    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authors = new List<string>(authors);
    }

    public string Title
    {
        get => this.title;
        private set => this.title = value;
    }

    public int Year
    {
        get => this.year;
        private set => this.year = value;
    }

    public IReadOnlyCollection<string> Authors
    {
        get => this.authors;
        set => this.authors = value;
    }

    public int CompareTo(Book other)
    {
        int yearComparement = this.Year.CompareTo(other.Year);
        if (yearComparement != 0)
        {
            return yearComparement;
        }

        return this.Title.CompareTo(other.Title);
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }
}