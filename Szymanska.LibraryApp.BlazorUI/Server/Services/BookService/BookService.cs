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

        public Book CreateBook(int id, string name, Author author, Publisher publisher, int releaseYear, Genre genre)
        {
            //return _bl.CreateNewBook(id, name, author, publisher, releaseYear, genre);
            
            var daoBook = _bl.CreateNewBook(id, name, author, publisher, releaseYear, genre);

            var sharedBook = new Book
            {
                Id = daoBook.Id,
                Name = daoBook.Name,
                Author = (Author)daoBook.Author,
                Publisher = (Publisher)daoBook.Publisher,
                ReleaseYear = daoBook.ReleaseYear,
                Genre = daoBook.Genre
            };

            return sharedBook;
        }

        public Book UpdateBook(int id, string name, Author author, Publisher publisher, int releaseYear, Genre genre)
        {
            //return (Book)_bl.UpdateBook(id, name, author, publisher, releaseYear, genre);

            var daoBook = _bl.UpdateBook(id, name, author, publisher, releaseYear, genre);

            var sharedBook = new Book
            {
                Id = daoBook.Id,
                Name = daoBook.Name,
                Author = (Author)daoBook.Author,
                Publisher = (Publisher)daoBook.Publisher,
                ReleaseYear = daoBook.ReleaseYear,
                Genre = daoBook.Genre
            };

            return sharedBook;
        }

        public void DeleteBook(int id)
        {
            _bl.DeleteBook(id);
        }
    }
}
