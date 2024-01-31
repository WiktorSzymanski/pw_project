using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Szymanska.LibraryApp.BlazorUI.Shared;
using Szymanski.LibraryApp.Interfaces;


namespace Szymanska.LibraryApp.BlazorUI.Client.Services.PublisherService
{
    public class PublisherService : IPublisherService
    {
        private readonly HttpClient _httpClient;

        public List<Publisher> Publishers { get; set; } = new List<Publisher>();

        public PublisherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetPublishers()
        {
            Publishers = await _httpClient.GetFromJsonAsync<List<Publisher>>("api/publisher");
        }

        public async Task<IPublisher> CreatePublisher(int id, string name)
        {
            var publisher = new Publisher { Id = id, Name = name };
            await _httpClient.PostAsJsonAsync("api/publisher", publisher);
            await GetPublishers();
            return publisher;
        }

        public async Task<IPublisher> UpdatePublisher(int id, string name)
        {
            var publisher = new Publisher { Id = id, Name = name };
            await _httpClient.PutAsJsonAsync($"api/publisher/{id}", publisher);
            await GetPublishers();
            return publisher;
        }

        public async Task DeletePublisher(int id)
        {
            await _httpClient.DeleteAsync($"api/publisher/{id}");
            await GetPublishers();
        }
    }
}
