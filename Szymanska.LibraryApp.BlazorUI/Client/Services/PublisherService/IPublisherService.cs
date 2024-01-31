using System.Collections.Generic;
using System.Threading.Tasks;
using Szymanski.LibraryApp.Interfaces;
using Szymanska.LibraryApp.BlazorUI.Shared;

namespace Szymanska.LibraryApp.BlazorUI.Client.Services.PublisherService
{
    public interface IPublisherService
    {
        List<Publisher> Publishers { get; set; }
        Task<IPublisher> CreatePublisher(int id, string name);
        Task<IPublisher> UpdatePublisher(int id, string name);
        Task GetPublishers();
        Task DeletePublisher(int id);
    }
}
