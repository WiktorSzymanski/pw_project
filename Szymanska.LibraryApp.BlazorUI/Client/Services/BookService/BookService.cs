using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Szymanska.LibraryApp.BlazorUI.Shared;
using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanska.LibraryApp.BlazorUI.Client.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public List<Book> Books { get; set; } = new List<Book>();

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetBooks()
        {
            Books = await _httpClient.GetFromJsonAsync<List<Book>>("api/book");
        }

        public async Task CreateBook(Book book)
        {
            await _httpClient.PostAsJsonAsync("api/book", book);
            await GetBooks();
        }

        public async Task UpdateBook(int id, Book book)
        {
            await _httpClient.PutAsJsonAsync($"api/book/{id}", book);
            await GetBooks();
        }

        public async Task DeleteBook(int id)
        {
            await _httpClient.DeleteAsync($"api/book/{id}");
            await GetBooks();
        }
    }
}
