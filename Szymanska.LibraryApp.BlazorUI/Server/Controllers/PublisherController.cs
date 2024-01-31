using Microsoft.AspNetCore.Mvc;
using Szymanska.LibraryApp.BlazorUI.Shared;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanska.LibraryApp.BlazorUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public IActionResult GetPublishers()
        {
            var publishers = _publisherService.GetPublishers();
            return Ok(publishers);
        }

        [HttpPost]
        public IActionResult CreatePublisher([FromBody] Publisher publisher)
        {
            var createdPublisher = _publisherService.CreatePublisher(publisher.Id, publisher.Name);
            return Ok(createdPublisher);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePublisher(int id, [FromBody] Publisher publisher)
        {
            var updatedPublisher = _publisherService.UpdatePublisher(id, publisher.Name);
            return Ok(updatedPublisher);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublisher(int id)
        {
            _publisherService.DeletePublisher(id);
            return Ok();
        }
    }
}
