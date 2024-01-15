using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.DAOMock.BO;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LibraryApp.DAOMock;

public class DAOMock: IDAO
{
    private List<IBook> _books;
    private List<IAuthor> _authors;
    private List<IPublisher> _publishers;

    public DAOMock()
    {
        _authors = new List<IAuthor>()
        {
            new Author() {Id = 1, Name = "DAMN", Surname = "DANIEL", BirthDate = new DateTime(2097,03,03)},
            new Author() {Id = 2, Name = "Daniel", Surname = "DAMN", BirthDate = new DateTime(2037,04,05)},
            new Author() {Id = 3, Name = "Adam", Surname = "DAMN", BirthDate = new DateTime(2077,06,01)},
        };

        _publishers = new List<IPublisher>()
        {
            new Publisher() { Id = 1, Name = "PublisherDaniel" },
            new Publisher() { Id = 2, Name = "DAMNPublisher" },
        };

        _books = new List<IBook>()
        {
            new Book()
            {
                Id = 1, Name = "Damn Book", Author = _authors[0], Publisher = _publishers[0], ReleaseYear = 2001, Genres =
                    new HashSet<Genre>()
                    {
                        Genre.Fantasy
                    }
            },
            new Book()
            {
                Id = 2, Name = "Book About Daniel", Author = _authors[1], Publisher = _publishers[0], ReleaseYear = 2000, Genres =
                    new HashSet<Genre>()
                    {
                        Genre.Horror,
                        Genre.Romance
                    }
            },
            new Book()
            {
                Id = 3, Name = "KaBook", Author = _authors[2], Publisher = _publishers[1], ReleaseYear = 1990, Genres =
                    new HashSet<Genre>()
                    {
                        Genre.Romance,
                        Genre.Fantasy
                    }
            },
        };
    }
    
    public IEnumerable<IBook> GetAllBooks()
    {
        return _books;
    }

    public IEnumerable<IAuthor> GetAllAuthors()
    {
        return _authors;
    }

    public IEnumerable<IPublisher> GetAllPublishers()
    {
        return _publishers;
    }

    public IBook CreateNewBook(int id, string name, IAuthor author, IPublisher publisher, int releaseYear, ISet<Genre> genres)
    {
        Book book = new Book()
        {
            Id = id, Name = name, Author = author, Publisher = publisher, ReleaseYear = releaseYear, Genres = genres
        };
        _books.Add(book);

        return book;
    }

    public IAuthor CreateNewAuthor(int id, string name, string surname, DateTime birthDate)
    {
        Author author = new Author()
        {
            Id = id, Name = name, Surname = surname, BirthDate = birthDate
        };
            
        _authors.Add(author);

        return author;
    }

    public IPublisher CreateNewPublisher(int id, string name)
    {
        Publisher publisher = new Publisher()
        {
            Id = id, Name = name
        };
            
        _publishers.Add(publisher);

        return publisher;
    }
}