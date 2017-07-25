using System.Collections.Generic;

public interface ILibrary : IEnumerable<Book>
{
    IList<Book> Books { get; }
}