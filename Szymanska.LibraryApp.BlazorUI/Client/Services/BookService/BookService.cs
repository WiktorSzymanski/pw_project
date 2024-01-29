using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanska.LibraryApp.BlazorUI.Client.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly BL _bl;

        public BookService(BL bl)
        {
            _bl = bl;
        }

        public List<IBook> Books { get; set; } = new List<IBook>();

        public async Task CreateBook(IBook book)
        {
            // Użyj odpowiedniej metody z warstwy BL do dodania książki
            _bl.CreateNewBook(book.Id, book.Name, book.Author, book.Publisher, book.ReleaseYear, book.Genre);

            // Pobierz zaktualizowaną listę książek
            await GetBooks();
        }

        public async Task DeleteBook(int id)
        {
            // Użyj odpowiedniej metody z warstwy BL do usunięcia książki
            _bl.DeleteBook(id);

            // Pobierz zaktualizowaną listę książek
            await GetBooks();
        }

        public async Task GetBooks()
        {
            // Użyj odpowiedniej metody z warstwy BL do pobrania wszystkich książek
            Books = _bl.GetBooks().ToList();
        }

        public async Task UpdateBook(int id, IBook book)
        {
            // Użyj odpowiedniej metody z warstwy BL do aktualizacji książki
            _bl.UpdateBook(id, book.Name, book.Author, book.Publisher, book.ReleaseYear, book.Genre);

            // Pobierz zaktualizowaną listę książek
            await GetBooks();
        }
    }
}
