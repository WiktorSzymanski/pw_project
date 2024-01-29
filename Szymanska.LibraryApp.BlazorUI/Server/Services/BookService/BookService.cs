using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.Interfaces;
using Szymanski.LibraryApp.DAOSQL;
using Szymanski.LibraryApp.DAOSQL.BO;

namespace Szymanska.LibraryApp.BlazorUI.Server.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<IBook> GetBooks()
        {
            return _context.Books.Include(book => book.Author)
                                 .Include(book => book.Publisher)
                                 .ToList();
        }

        public IBook CreateBook(int id, string name, IAuthor author, IPublisher publisher, int releaseYear, Genre genre)
        {
            var book = new Book
            {
                Id = id,
                Name = name,
                Author = (Author)author,
                Publisher = (Publisher)publisher,
                ReleaseYear = releaseYear,
                Genre = genre
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            return book;
        }

        public IBook UpdateBook(int id, string name, IAuthor author, IPublisher publisher, int releaseYear, Genre genre)
        {
            var book = _context.Books.Find(id);

            if (book != null)
            {
                book.Name = name;
                book.Author = (Author)author;
                book.Publisher = (Publisher)publisher;
                book.ReleaseYear = releaseYear;
                book.Genre = genre;

                _context.SaveChanges();
            }

            return book;
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);

            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
