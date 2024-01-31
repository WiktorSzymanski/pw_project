using System.Collections.Generic;
using Szymanska.LibraryApp.BlazorUI.Shared;
using Szymanski.LibraryApp.Interfaces;
using Szymanski.LibraryApp.BL;

namespace Szymanska.LibraryApp.BlazorUI.Server.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly BL _bl;

        public AuthorService(BL bl)
        {
            _bl = bl;
        }

        public IEnumerable<IAuthor> GetAuthors()
        {
            return _bl.GetAuthors();
        }

        public IAuthor CreateAuthor(int id, string name, string surname, DateTime birthDate)
        {
            return _bl.CreateNewAuthor(id, name, surname, birthDate);
        }

        public IAuthor UpdateAuthor(int id, string name, string surname, DateTime birthDate)
        {
            return _bl.UpdateAuthor(id, name, surname, birthDate);
        }

        public void DeleteAuthor(int id)
        {
            _bl.DeleteAuthor(id);
        }
    }
}
