using Szymanski.LibraryApp.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanska.LibraryApp.BlazorUI.Client.Services.BookService
{
    public interface IBookService
    {
        List<IBook> Books { get; set; }

        Task CreateBook(IBook book);
        Task DeleteBook(int id);
        Task GetBooks();
        Task UpdateBook(int id, IBook book);
    }
}
