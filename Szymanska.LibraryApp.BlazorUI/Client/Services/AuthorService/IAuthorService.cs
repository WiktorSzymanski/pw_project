using System.Collections.Generic;
using System.Threading.Tasks;
using Szymanska.LibraryApp.BlazorUI.Shared;

namespace Szymanska.LibraryApp.BlazorUI.Client.Services.AuthorService
{
    public interface IAuthorService
    {
        List<Author> Authors { get; set; }

        Task CreateAuthor(Author author);
        Task DeleteAuthor(int id);
        Task GetAuthors();
        Task UpdateAuthor(int id, Author author);
    }
}
