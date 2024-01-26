using Szymanski.LibraryApp.Core;
namespace Szymanski.LibraryApp.Interfaces;

public interface IDAO
{
    IEnumerable<IBook> GetAllBooks();
    IEnumerable<IAuthor> GetAllAuthors();
    IEnumerable<IPublisher> GetAllPublishers();

    IBook CreateNewBook(int id, string name, IAuthor? author, IPublisher? publisher, int releaseYear, Genre genre);
    IAuthor CreateNewAuthor(int id, string name, string surname, DateTime birthDate);
    IPublisher CreateNewPublisher(int id, string name);
    
    IBook UpdateBook(int id, string name, IAuthor? author, IPublisher? publisher, int releaseYear, Genre genre);
    IAuthor UpdateAuthor(int id, string name, string surname, DateTime birthDate);
    IPublisher UpdatePublisher(int id, string name);
    
    void DeleteBook(int id);
    void DeleteAuthor(int id);
    void DeletePublisher(int id);
}