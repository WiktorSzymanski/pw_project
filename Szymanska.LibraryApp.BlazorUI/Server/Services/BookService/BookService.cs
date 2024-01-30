using System.Collections.Generic;
using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.Interfaces;
using Szymanska.LibraryApp.BlazorUI.Shared;

namespace Szymanska.LibraryApp.BlazorUI.Server.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly BL _bl;

        public BookService(BL bl)
        {
            _bl = bl;
        }

        public IEnumerable<IBook> GetBooks()
        {
            return _bl.GetBooks();
        }

        public Book CreateBook(int id, string name, IAuthor author, IPublisher publisher, int releaseYear, Genre genre)
        {
            return (Book)_bl.CreateNewBook(id, name, author, publisher, releaseYear, genre);
        }

        public Book UpdateBook(int id, string name, IAuthor author, IPublisher publisher, int releaseYear, Genre genre)
        {
            return (Book)_bl.UpdateBook(id, name, author, publisher, releaseYear, genre);
        }

        public void DeleteBook(int id)
        {
            _bl.DeleteBook(id);
        }
    }
}
