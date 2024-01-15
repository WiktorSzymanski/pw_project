using Szymanski.LibraryApp.Core;
namespace Szymanski.LibraryApp.Interfaces;

public interface IDAO
{
    IEnumerable<IBook> GetAllBooks();
    IEnumerable<IAuthor> GetAllAuthors();
    IEnumerable<IPublisher> GetAllPublishers();

    IBook CreateNewBook(int id, string name, IAuthor author, IPublisher publisher, int releaseYear, ISet<Genre> genres);
    IAuthor CreateNewAuthor(int id, string name, string surname, DateTime birthDate);
    IPublisher CreateNewPublisher(int id, string name);
}