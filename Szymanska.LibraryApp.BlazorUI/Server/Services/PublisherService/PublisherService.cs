using System.Collections.Generic;
using Szymanska.LibraryApp.BlazorUI.Shared;
using Szymanski.LibraryApp.Interfaces;
using Szymanski.LibraryApp.BL;

namespace Szymanska.LibraryApp.BlazorUI.Server.Services.PublisherService
{
    public class PublisherService : IPublisherService
    {
        private readonly BL _bl;

        public PublisherService(BL bl)
        {
            _bl = bl;
        }

        public IEnumerable<IPublisher> GetPublishers()
        {
            return _bl.GetPublishers();
        }

        public IPublisher CreatePublisher(int id, string name)
        {
            return _bl.CreateNewPublisher(id, name);
        }

        public IPublisher UpdatePublisher(int id, string name)
        {
            return _bl.UpdatePublisher(id, name);
        }

        public void DeletePublisher(int id)
        {
            _bl.DeletePublisher(id);
        }
    }
}
