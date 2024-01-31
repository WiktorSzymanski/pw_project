using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Szymanska.LibraryApp.BlazorUI.Shared;

namespace Szymanska.LibraryApp.BlazorUI.Client.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly HttpClient _httpClient;

        public List<Author> Authors { get; set; } = new List<Author>();

        public AuthorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetAuthors()
        {
            Authors = await _httpClient.GetFromJsonAsync<List<Author>>("api/author");
        }

        public async Task CreateAuthor(Author author)
        {
            await _httpClient.PostAsJsonAsync("api/author", author);
            await GetAuthors();
        }

        public async Task UpdateAuthor(int id, Author author)
        {
            await _httpClient.PutAsJsonAsync($"api/author/{id}", author);
            await GetAuthors();
        }

        public async Task DeleteAuthor(int id)
        {
            await _httpClient.DeleteAsync($"api/author/{id}");
            await GetAuthors();
        }
    }
}
