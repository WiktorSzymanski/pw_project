using Szymanski.LibraryApp.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Szymanski.LibraryApp.Interfaces;
using Szymanska.LibraryApp.BlazorUI.Shared;

namespace Szymanska.LibraryApp.BlazorUI.Client.Services.BookService
{
    public interface IBookService
    {
        List<Book> Books { get; set; }

        Task CreateBook(Book book);
        Task DeleteBook(int id);
        Task GetBooks();
        Task UpdateBook(int id, Book book);
    }
}