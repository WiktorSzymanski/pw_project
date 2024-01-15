using Szymanski.LibraryApp.Interfaces;
using Szymanski.LibraryApp.Core;
using System.Reflection;

namespace Szymanski.LibraryApp.BL;

public class BL
{
    private IDAO _dao;

    // Make it singleton
    public BL(string libraryName)
    {
        Assembly assembly = Assembly.UnsafeLoadFrom(libraryName);

        Type? typeToCreate = null;

        foreach (Type t in assembly.GetTypes())
        {
            if (t.IsAssignableTo(typeof(IDAO)))
            {
                typeToCreate = t;
                break;
            }
        }

        _dao = (IDAO)Activator.CreateInstance(typeToCreate, null);
    }

    public IEnumerable<IBook> GetBooks() => _dao.GetAllBooks();
    public IEnumerable<IAuthor> GetAuthors() => _dao.GetAllAuthors();
    public IEnumerable<IPublisher> GetPublishers() => _dao.GetAllPublishers();

    public IBook
        CreateNewBook(int id, string name, IAuthor author, IPublisher publisher, int releaseYear, ISet<Genre> genres) =>
        _dao.CreateNewBook(id, name, author, publisher, releaseYear, genres);
    
    public IAuthor CreateNewAuthor(int id, string name, string surname, DateTime birthDate) =>
        _dao.CreateNewAuthor(id, name, surname, birthDate);
    
    public IPublisher CreateNewPublisher(int id, string name) =>
        _dao.CreateNewPublisher(id, name);
}
