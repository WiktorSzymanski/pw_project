using Microsoft.EntityFrameworkCore;
using Szymanski.LibraryApp.Interfaces;
using Szymanski.LibraryApp.DAOSQL.BO;
using Szymanski.LibraryApp.Core;

namespace Szymanski.LibraryApp.DAOSQL;

public class DAOSQL : IDAO
{
    private readonly AppDbContext _context;

    public DAOSQL()
    {
        _context = new AppDbContext();
    }

    public IEnumerable<IBook> GetAllBooks()
    {
        return _context.Books.Include(book => book.Author)
            .Include(book => book.Publisher)
            .Select(book => book as IBook).ToList();
    }

    public IEnumerable<IAuthor> GetAllAuthors()
    {
        return _context.Authors.ToList();
    }

    public IEnumerable<IPublisher> GetAllPublishers()
    {
        return _context.Publishers.ToList();
    }

    public IBook CreateNewBook(int id, string name, IAuthor author, IPublisher publisher, int releaseYear, Genre genre)
    {
        var book = new Book
        {
            Name = name,
            Author = (Author) author,
            Publisher = (Publisher) publisher,
            ReleaseYear = releaseYear,
            Genre = genre
        };
        _context.Books.Add(book);
        _context.SaveChanges();
        return (IBook) book;
    }

    public IAuthor CreateNewAuthor(int id, string name, string surname, DateTime birthDate)
    {
        var author = new Author
        {
            Name = name,
            Surname = surname,
            BirthDate = birthDate
        };
        _context.Authors.Add(author);
        _context.SaveChanges();
        return author;
    }

    public IPublisher CreateNewPublisher(int id, string name)
    {
        var publisher = new Publisher { Name = name };
        _context.Publishers.Add(publisher);
        _context.SaveChanges();
        return publisher;
    }

    public IBook UpdateBook(int id, string name, IAuthor author, IPublisher publisher, int releaseYear, Genre genre)
    {
        var book = _context.Books.Find(id);
        if (book != null)
        {
            book.Name = name;
            book.Author = (Author) author;
            book.Publisher = (Publisher) publisher;
            book.ReleaseYear = releaseYear;
            book.Genre = genre;
            _context.SaveChanges();
        }
        return (IBook) book;
    }

    public IAuthor UpdateAuthor(int id, string name, string surname, DateTime birthDate)
    {
        var author = _context.Authors.Find(id);
        if (author != null)
        {
            author.Name = name;
            author.Surname = surname;
            author.BirthDate = birthDate;
            _context.SaveChanges();
        }
        return author;
    }

    public IPublisher UpdatePublisher(int id, string name)
    {
        var publisher = _context.Publishers.Find(id);
        if (publisher != null)
        {
            publisher.Name = name;
            _context.SaveChanges();
        }
        return publisher;
    }

    public void DeleteBook(int id)
    {
        var book = _context.Books.Find(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }

    public void DeleteAuthor(int id)
    {
        var author = _context.Authors.Find(id);
        if (author != null)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }

    public void DeletePublisher(int id)
    {
        var publisher = _context.Publishers.Find(id);
        if (publisher != null)
        {
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
        }
    }
}