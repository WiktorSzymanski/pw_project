using Szymanska.LibraryApp.BlazorUI.Shared;
using System.Collections.Generic;

namespace Szymanski.LibraryApp.Interfaces
{
    public interface IPublisherService
    {
        IEnumerable<IPublisher> GetPublishers();
        IPublisher CreatePublisher(int id, string name);
        IPublisher UpdatePublisher(int id, string name);
        void DeletePublisher(int id);
    }
}