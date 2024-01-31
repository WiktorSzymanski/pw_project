using Microsoft.AspNetCore.Mvc;
using Szymanska.LibraryApp.BlazorUI.Shared;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanska.LibraryApp.BlazorUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _authorService.GetAuthors();
            return Ok(authors);
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] Author author)
        {
            var createdAuthor = _authorService.CreateAuthor(author.Id, author.Name, author.Surname, author.BirthDate);
            return Ok(createdAuthor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] Author author)
        {
            var updatedAuthor = _authorService.UpdateAuthor(id, author.Name, author.Surname, author.BirthDate);
            return Ok(updatedAuthor);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            _authorService.DeleteAuthor(id);
            return Ok();
        }
    }
}
