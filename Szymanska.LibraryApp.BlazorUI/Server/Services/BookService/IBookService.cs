using System.Collections.Generic;
using Szymanska.LibraryApp.BlazorUI.Shared;
using Szymanski.LibraryApp.Core;


namespace Szymanski.LibraryApp.Interfaces
{
    public interface IBookService
    {
        IEnumerable<IBook> GetBooks();
        Book CreateBook(int id, string name, Author author, Publisher publisher, int releaseYear, Genre genre);
        Book UpdateBook(int id, string name, Author author, Publisher publisher, int releaseYear, Genre genre);
        void DeleteBook(int id);
    }
}
