using Szymanska.LibraryApp.BlazorUI.Shared;
using System.Collections.Generic;

namespace Szymanski.LibraryApp.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<IAuthor> GetAuthors();
        IAuthor CreateAuthor(int id, string name, string surname, DateTime birthDate);
        IAuthor UpdateAuthor(int id, string name, string surname, DateTime birthDate);
        void DeleteAuthor(int id);
    }
}
