using System.Collections.Generic;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        int titleComparement = x.Title.CompareTo(y.Title);
        if (titleComparement != 0)
        {
            return titleComparement;
        }

        return y.Year.CompareTo(x.Year);
    }
}