using Szymanski.LibraryApp.Core;
namespace Szymanski.LibraryApp.Interfaces;

public interface IBook
{
    int Id { get; set; }
    string Name { get; set; }
    IAuthor Author { get; set; }
    IPublisher Publisher { get; set; }
    int ReleaseYear { get; set; }
    ISet<Genre> Genres { get; set; }
}