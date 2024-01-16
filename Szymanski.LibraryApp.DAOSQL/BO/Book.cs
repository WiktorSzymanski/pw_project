using System.ComponentModel.DataAnnotations.Schema;
using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LibraryApp.DAOSQL.BO;

public class Book : IBook
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Author Author { get; set; }
    public Publisher Publisher { get; set; }
    public int ReleaseYear { get; set; }
    public ICollection<Genre> Genres { get; set; }

    [NotMapped]
    IAuthor IBook.Author
    {
        get
        {
            return Author;
        }
        set
        {
            Author = (Author) value;
        }
    }
    [NotMapped] IPublisher IBook.Publisher
    {
        get
        {
            return Publisher;
        }
        set
        {
            Publisher = (Publisher) value;
        }
    }
}