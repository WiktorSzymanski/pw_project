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

        public IBook CreateBook(int id, string name, IAuthor author, IPublisher publisher, int releaseYear, Genre genre)
        {
            return _bl.CreateNewBook(id, name, author, publisher, releaseYear, genre);

            //var newBook = _bl.CreateNewBook(id, name, author, publisher, releaseYear, genre);

            //var mappedBook = new Book
            //{
            //    Id = newBook.Id,
            //    Name = newBook.Name,
            //    Author = newBook.Author != null ? MapAuthor(newBook.Author) : null,
            //    Publisher = newBook.Publisher != null ? MapPublisher(newBook.Publisher) : null,
            //    ReleaseYear = newBook.ReleaseYear,
            //    Genre = newBook.Genre
            //};

            //return mappedBook;
        }

        public IBook UpdateBook(int id, string name, IAuthor author, IPublisher publisher, int releaseYear, Genre genre)
        {
            return _bl.UpdateBook(id, name, author, publisher, releaseYear, genre);

            //var updatedBook = _bl.UpdateBook(id, name, author, publisher, releaseYear, genre);

            //var mappedBook = new Book
            //{
            //    Id = updatedBook.Id,
            //    Name = updatedBook.Name,
            //    Author = updatedBook.Author != null ? MapAuthor(updatedBook.Author) : null,
            //    Publisher = updatedBook.Publisher != null ? MapPublisher(updatedBook.Publisher) : null,
            //    ReleaseYear = updatedBook.ReleaseYear,
            //    Genre = updatedBook.Genre
            //};

            //return mappedBook;
        }

        public void DeleteBook(int id)
        {
            _bl.DeleteBook(id);
        }

        //private Author MapAuthor(IAuthor author)
        //{
        //    return new Author
        //    {
        //        Id = author.Id,
        //        Name = author.Name,
        //        Surname = author.Surname,
        //        BirthDate = author.BirthDate
        //    };
        //}

        //private Publisher MapPublisher(IPublisher publisher)
        //{
        //    return new Publisher
        //    {
        //        Id = publisher.Id,
        //        Name = publisher.Name
        //    };
        //}
    }
}
