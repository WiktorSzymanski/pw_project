using Microsoft.AspNetCore.Mvc;
using Szymanska.LibraryApp.BlazorUI.Shared;
using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LibraryApp.BlazorUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookService.GetBooks();
            return Ok(books);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            var createdBook = _bookService.CreateBook(book.Id, book.Name, book.Author, book.Publisher, book.ReleaseYear, book.Genre);
            return Ok(createdBook);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            var updatedBook = _bookService.UpdateBook(id, book.Name, book.Author, book.Publisher, book.ReleaseYear, book.Genre);
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return Ok();
        }
    }
}
