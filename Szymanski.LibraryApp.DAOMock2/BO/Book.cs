using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LibraryApp.DAOMock2.BO;

public class Book: IBook
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IAuthor Author { get; set; }
    public IPublisher Publisher { get; set; }
    public int ReleaseYear { get; set; }
    public ICollection<Genre> Genres { get; set; }
}